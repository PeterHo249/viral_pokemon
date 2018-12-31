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

    public void readDataFromSqlite()
    {
        //Read Data
        string path = "URI=file://Assets/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;
        IDataReader dbr;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();
        dbcm.CommandText = "select SamplePokemon.id, SamplePokemon.name, SamplePokemon.hp, SamplePokemon.attack, SamplePokemon.defense, SamplePokemon.speed, PokemonOfPlayer.level, PokemonOfPlayer.exp from SamplePokemon, PokemonOfPlayer where SamplePokemon.id = PokemonOfPlayer.idPokemon";
        dbr = dbcm.ExecuteReader();


        // Read stat, level, exp
        while (dbr.Read())
        {
            //SamplePokemon sample = new SamplePokemon(dbr.GetString(0), dbr.GetInt32(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetInt32(5), dbr.GetInt32(6)); // 0,1,2,3,.. : index của name, hp, .. sau khi query
            //OwnedPokemon pokemon = new OwnedPokemon(sample, dbr.GetInt32(7), dbr.GetInt32(8));
            //ownedPokemons.Add(pokemon);

            Pokemon pokemon = new Pokemon(dbr.GetInt32(0), dbr.GetString(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetInt32(5), dbr.GetInt32(6));
            ownedPokemons.Add(pokemon);
        }

        // Read type and skill
        for (int i = 0; i < ownedPokemons.Count; i++)
        {
            // Read skill
            dbcm.CommandText = "select PokemonSkill.name, PokemonType.name, PokemonSkill.power, PokemonSkill.accurate, PokemonSkill.pp, PokemonSkill.effect from PokemonSkill, PokemonType, SamplePokemon, SkillOfPokemon where PokemonSkill.type = PokemonType.id and PokemonSkill.id = SkillOfPokemon.idSkill and SkillOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.name = '";
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                //ownedPokemons[i].samplePokemon.pokemonSkill.Add(new PokemonSkill(dbr.GetString(0), mapping[dbr.GetString(1)], dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetString(5)));
            }

            // Read Type
            dbcm.CommandText = "select PokemonType.name from PokemonType, TypeOfPokemon, SamplePokemon where PokemonType.id = TypeOfPokemon.idType and TypeOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.name = '";
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                //ownedPokemons[i].samplePokemon.pokemonType.Add(mapping[dbr.GetString(0)]);
            }
        }

        // Read Item
        dbcm.CommandText = "select Item.name, Item.effect, ItemOfPlayer.amount from Item, ItemOfPlayer where Item.id = ItemOfPlayer.idItem";
        dbr = dbcm.ExecuteReader();
        while (dbr.Read())
        {
            //ownedItems.Add(new OwnedItem(new Item(dbr.GetString(0), dbr.GetString(1)), dbr.GetInt32(2)));
        }

        dbc.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        //ownedPokemons = new List<OwnedPokemon>();
        //ownedItems = new List<OwnedItem>();
        readDataFromSqlite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
