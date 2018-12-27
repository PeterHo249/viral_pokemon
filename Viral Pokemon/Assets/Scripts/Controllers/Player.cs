using Assets.Scripts.Models;
using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

//public class OwnedPokemon
//{
//    public SamplePokemon samplePokemon;
//    public int level;
//    public int exp;

//    public OwnedPokemon(SamplePokemon sample, int lv, int exp)
//    {
//        this.samplePokemon = sample;
//        this.level = lv;
//        this.exp = exp;
//    }

//    public void scaleStatByLevel()
//    {
//        // giả sử Mỗi lv tăng 2 chỉ số, dùng hàm để lấy chỉ số thực của pokemon, gọi khi clone pokemon vào battle
//        samplePokemon.hp += 2 * level;
//        samplePokemon.attack += 2 * level;
//        samplePokemon.defense += 2 * level;
//        samplePokemon.spAttack += 2 * level;
//        samplePokemon.spDefense += 2 * level;
//        samplePokemon.speed += 2 * level;
//    }

//    public void checkLevelUp()
//    {
//        // Giả sử exp tăng theo hàm số f =  2^level
//        if (exp >= Math.Pow(2, level))
//        {
//            exp -= (int) Math.Pow(2, level);
//            level += 1;
//        }
//    }
//}

//public class OwnedItem
//{
//    public Item sampleItem;
//    public int amount;

//    public OwnedItem(Item item, int amt)
//    {
//        this.sampleItem = item;
//        this.amount = amt;
//    }
//}


public class Player : MonoBehaviour
{

    public List<OwnedPokemon> ownedPokemons;
    public List<OwnedItem> ownedItems;

    public void readDataFromSqlite()
    {
        //Mapping enum vs string
        Dictionary<string, PokemonType> mapping = new Dictionary<string, PokemonType>();
        mapping.Add("Normal", PokemonType.Normal);
        mapping.Add("Fire", PokemonType.Fire);
        mapping.Add("Water", PokemonType.Water);
        mapping.Add("Electric", PokemonType.Electric);
        mapping.Add("Grass", PokemonType.Grass);
        mapping.Add("Ice", PokemonType.Ice);
        mapping.Add("Fighting", PokemonType.Fighting);
        mapping.Add("Posion", PokemonType.Posion);
        mapping.Add("Ground", PokemonType.Ground);
        mapping.Add("Flying", PokemonType.Flying);
        mapping.Add("Psychic", PokemonType.Psychic);
        mapping.Add("Bug", PokemonType.Bug);
        mapping.Add("Rock", PokemonType.Rock);
        mapping.Add("Ghost", PokemonType.Ghost);
        mapping.Add("Dragon", PokemonType.Dragon);
        mapping.Add("Dark", PokemonType.Dark);
        mapping.Add("Steel", PokemonType.Steel);
        mapping.Add("Fairy", PokemonType.Fairy);



        //Read Data
        string path = "URI=file://Assets/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;
        IDataReader dbr;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();
        dbcm.CommandText = "Select SamplePokemon.name, SamplePokemon.hp, SamplePokemon.attack, SamplePokemon.defense, SamplePokemon.spAttack, SamplePokemon.spDefense, SamplePokemon.speed, PokemonOfPlayer.level, PokemonOfPlayer.exp from SamplePokemon, PokemonOfPlayer where SamplePokemon.id = PokemonOfPlayer.idPokemon";
        dbr = dbcm.ExecuteReader();


        // Read stat, level, exp
        while (dbr.Read())
        {
            SamplePokemon sample = new SamplePokemon(dbr.GetString(0), dbr.GetInt32(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetInt32(5), dbr.GetInt32(6)); // 0,1,2,3,.. : index của name, hp, .. sau khi query
            OwnedPokemon pokemon = new OwnedPokemon(sample, dbr.GetInt32(7), dbr.GetInt32(8));
            ownedPokemons.Add(pokemon);
        }

        // Read type and skill
        for (int i = 0; i < ownedPokemons.Count; i++)
        {
            // Read skill
            dbcm.CommandText = "select PokemonSkill.name, PokemonType.name, PokemonSkill.power, PokemonSkill.accurate, PokemonSkill.pp, PokemonSkill.effect from PokemonSkill, PokemonType, SamplePokemon, SkillOfPokemon where PokemonSkill.type = PokemonType.id and PokemonSkill.id = SkillOfPokemon.idSkill and SkillOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.name = '" + ownedPokemons[i].samplePokemon.pokemonName + "'";
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                ownedPokemons[i].samplePokemon.pokemonSkill.Add(new PokemonSkill(dbr.GetString(0), mapping[dbr.GetString(1)], dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetString(5)));
            }

            // Read Type
            dbcm.CommandText = "select PokemonType.name from PokemonType, TypeOfPokemon, SamplePokemon where PokemonType.id = TypeOfPokemon.idType and TypeOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.name = '" + ownedPokemons[i].samplePokemon.pokemonName + "'";
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                ownedPokemons[i].samplePokemon.pokemonType.Add(mapping[dbr.GetString(0)]);
            }
        }

        // Read Item
        dbcm.CommandText = "select Item.name, Item.effect, ItemOfPlayer.amount from Item, ItemOfPlayer where Item.id = ItemOfPlayer.idItem";
        dbr = dbcm.ExecuteReader();
        while (dbr.Read())
        {
            ownedItems.Add(new OwnedItem(new Item(dbr.GetString(0), dbr.GetString(1)), dbr.GetInt32(2)));
        }

        dbc.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        ownedPokemons = new List<OwnedPokemon>();
        ownedItems = new List<OwnedItem>();
        readDataFromSqlite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
