using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class Player : MonoBehaviour
{

    public List<Pokemon> ownedPokemons;
    public List<Item> ownedItems;

    public int Money;

    public void readDataFromSqlite()
    {
        ownedPokemons = new List<Pokemon>();
        ownedItems = new List<Item>();

        //Read Data
        string path = "URI=file://Assets/Database/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;
        IDataReader dbr;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();
        dbcm.CommandText = "select SamplePokemon.id, SamplePokemon.name, SamplePokemon.hp, SamplePokemon.attack, SamplePokemon.defense, SamplePokemon.speed, PokemonOfPlayer.level from SamplePokemon, PokemonOfPlayer where SamplePokemon.id = PokemonOfPlayer.idPokemon";
        dbr = dbcm.ExecuteReader();


        // Read stat, level, exp
        while (dbr.Read())
        {
            Pokemon pokemon = new Pokemon(dbr.GetInt32(0), dbr.GetString(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetInt32(5), dbr.GetInt32(6));
            ownedPokemons.Add(pokemon);
        }

        // Read type and skill
        for (int i = 0; i < ownedPokemons.Count; i++)
        {
            // Read skill
            dbcm.CommandText = "select PokemonSkill.id, PokemonSkill.name, PokemonSkill.type, PokemonSkill.power, PokemonSkill.pp from PokemonSkill, PokemonType, SamplePokemon, SkillOfPokemon where PokemonSkill.type = PokemonType.id and PokemonSkill.id = SkillOfPokemon.idSkill and SkillOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.id = " + ownedPokemons[i].id.ToString();
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                ownedPokemons[i].skills.Add(new PokemonSkill(dbr.GetInt32(0), dbr.GetString(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4)));
            }

            // Read Type
            dbcm.CommandText = "select TypeOfPokemon.idType from TypeOfPokemon, SamplePokemon where TypeOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.id = " + ownedPokemons[i].id.ToString();
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                ownedPokemons[i].type.Add(dbr.GetInt32(0));
            }
        }

        // Read Item
        dbcm.CommandText = "select Item.id, Item.name, ItemOfPlayer.amount from Item, ItemOfPlayer where Item.id = ItemOfPlayer.idItem";
        dbr = dbcm.ExecuteReader();
        while (dbr.Read())
        {
            ownedItems.Add(new Item(dbr.GetInt32(0), dbr.GetString(1), dbr.GetInt32(2)));
        }

        // load money
        dbcm.CommandText = "select money from PlayerInfo";
        dbr = dbcm.ExecuteReader();

        while (dbr.Read())
        {
            Money = dbr.GetInt32(0);
        }

        dbc.Close();

        Debug.Log("Load: " + ownedItems);
    }

    void SaveData()
    {
        string path = "URI=file://Assets/Database/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();


        // Save item
        Debug.Log("Save: " + ownedItems);
        if (ownedItems != null)
        {
            for (int i = 0; i < ownedItems.Count; i++)
            {
                dbcm.CommandText = "update ItemOfPlayer set amount = " + ownedItems[i].amount.ToString() + " where idItem = " + ownedItems[i].id.ToString();
                dbcm.ExecuteScalar();
            }
        }

        // Money
        if (Money > 0)
        {
            dbcm.CommandText = "update PlayerInfo set Money = " + Money.ToString();
            dbcm.ExecuteScalar();

        }



        // Save pokemon

        if (ownedPokemons != null)
        {
            dbcm.CommandText = "delete from PokemonOfPlayer";
            dbcm.ExecuteNonQuery();

            for (int i =0; i<ownedPokemons.Count; i++)
            {
                dbcm.CommandText = "insert into PokemonOfPlayer(idPokemon, level) values (" + ownedPokemons[i].id.ToString() + ", " + ownedPokemons[i].level.ToString() + ")";
                dbcm.ExecuteNonQuery();
            }
        }

        dbc.Close();
    }


    // Start is called before the first frame update
    void Start()
    {
        readDataFromSqlite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        SaveData();
    }
}
