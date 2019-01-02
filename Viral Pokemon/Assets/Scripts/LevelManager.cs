using Mono.Data.SqliteClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public List<Pokemon> Collection;
    public bool state;
    public static int level = 0;
    public static List<List<Pokemon>> dataLevel;

    public void LoadData()
    {
        Collection = new List<Pokemon>();

        //Read Data
        string path = "URI=file://Assets/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;
        IDataReader dbr;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();
        dbcm.CommandText = "select SamplePokemon.id, SamplePokemon.name, SamplePokemon.hp, SamplePokemon.attack, SamplePokemon.defense, SamplePokemon.speed from SamplePokemon";
        dbr = dbcm.ExecuteReader();


        // Read stat, level, exp
        while (dbr.Read())
        {
            Pokemon pokemon = new Pokemon(dbr.GetInt32(0), dbr.GetString(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4), dbr.GetInt32(5), 1);
            Collection.Add(pokemon);
        }

        // Read type and skill
        for (int i = 0; i < Collection.Count; i++)
        {
            // Read skill
            dbcm.CommandText = "select PokemonSkill.id, PokemonSkill.name, PokemonSkill.type, PokemonSkill.power, PokemonSkill.pp from PokemonSkill, PokemonType, SamplePokemon, SkillOfPokemon where PokemonSkill.type = PokemonType.id and PokemonSkill.id = SkillOfPokemon.idSkill and SkillOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.id = " + Collection[i].id.ToString();
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                Collection[i].skills.Add(new PokemonSkill(dbr.GetInt32(0), dbr.GetString(1), dbr.GetInt32(2), dbr.GetInt32(3), dbr.GetInt32(4)));
            }

            // Read Type
            dbcm.CommandText = "select TypeOfPokemon.idType from TypeOfPokemon, SamplePokemon where TypeOfPokemon.idPokemon = SamplePokemon.id and SamplePokemon.id = " + Collection[i].id.ToString();
            dbr = dbcm.ExecuteReader();
            while (dbr.Read())
            {
                Collection[i].type.Add(dbr.GetInt32(0));
            }
        }

        dbc.Close();
    }

    public void PrepareData()
    {
        dataLevel = new List<List<Pokemon>>();
        dataLevel.Add(new List<Pokemon>() { Collection[0].Clone(), Collection[1].Clone(), Collection[2].Clone(), Collection[3].Clone(), Collection[4].Clone(), Collection[5].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });


        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[9], Collection[10], Collection[11] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[9], Collection[10], Collection[11] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[9], Collection[10], Collection[11] });



        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[3], Collection[4], Collection[5] });
        dataLevel.Add(new List<Pokemon>() { Collection[0], Collection[1], Collection[2], Collection[6], Collection[7], Collection[8] });
        dataLevel.Add(new List<Pokemon>() { Collection[3], Collection[4], Collection[5], Collection[6], Collection[7], Collection[8] });

    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        PrepareData();
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
