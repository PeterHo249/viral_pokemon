using Mono.Data.SqliteClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public List<Pokemon> Collection;

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

    public List<Pokemon> RandomPokemons(int typePokemon)
    {
        List<Pokemon> ret = new List<Pokemon>();
        List<Pokemon> temp = new List<Pokemon>();

        foreach (Pokemon p in Collection)
        {
            if (p.type.Count == 2)
            {
                if (p.type[0] == typePokemon || p.type[1] == typePokemon)
                {
                    temp.Add(p.Clone());
                }
                    
            }
            if (p.type.Count == 1)
            {
                if (p.type[0] == typePokemon)
                {
                    temp.Add(p.Clone());
                }
                    
            }

        }

        for (int i = 0; i < 2; i++ )
        {
            System.Random r = new System.Random();
            int k = r.Next(0, temp.Count);
            ret.Add(temp[k].Clone());
            temp.RemoveAt(k);
            
        }
        Debug.Log(ret[0].pokemonName);
        Debug.Log(ret[1].pokemonName);
        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        RandomPokemons(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
