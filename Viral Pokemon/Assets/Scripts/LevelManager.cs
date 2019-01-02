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
        dataLevel.Add(new List<Pokemon>() { Collection[0].Clone(), Collection[1].Clone(), Collection[2].Clone(), Collection[6].Clone(), Collection[7].Clone(), Collection[8].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[3].Clone(), Collection[4].Clone(), Collection[5].Clone(), Collection[6].Clone(), Collection[7].Clone(), Collection[8].Clone() });


        dataLevel.Add(new List<Pokemon>() { Collection[3].Clone(), Collection[4].Clone(), Collection[5].Clone(), Collection[9].Clone(), Collection[10].Clone(), Collection[11].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[3].Clone(), Collection[4].Clone(), Collection[5].Clone(), Collection[9].Clone(), Collection[10].Clone(), Collection[11].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[3].Clone(), Collection[4].Clone(), Collection[5].Clone(), Collection[9].Clone(), Collection[10].Clone(), Collection[11].Clone() });


        dataLevel.Add(new List<Pokemon>() { Collection[6].Clone(), Collection[7].Clone(), Collection[8].Clone(), Collection[12].Clone(), Collection[13].Clone(), Collection[14].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[6].Clone(), Collection[7].Clone(), Collection[8].Clone(), Collection[12].Clone(), Collection[13].Clone(), Collection[14].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[6].Clone(), Collection[7].Clone(), Collection[8].Clone(), Collection[12].Clone(), Collection[13].Clone(), Collection[14].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[0].Clone(), Collection[1].Clone(), Collection[2].Clone(), Collection[15].Clone(), Collection[16].Clone(), Collection[17].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[0].Clone(), Collection[1].Clone(), Collection[2].Clone(), Collection[15].Clone(), Collection[16].Clone(), Collection[17].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[0].Clone(), Collection[1].Clone(), Collection[2].Clone(), Collection[15].Clone(), Collection[16].Clone(), Collection[17].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[18].Clone(), Collection[19].Clone(), Collection[20].Clone(), Collection[21].Clone(), Collection[22].Clone(), Collection[23].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[18].Clone(), Collection[19].Clone(), Collection[20].Clone(), Collection[21].Clone(), Collection[22].Clone(), Collection[23].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[18].Clone(), Collection[19].Clone(), Collection[20].Clone(), Collection[21].Clone(), Collection[22].Clone(), Collection[23].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[24].Clone(), Collection[25].Clone(), Collection[26].Clone(), Collection[27].Clone(), Collection[28].Clone(), Collection[29].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[24].Clone(), Collection[25].Clone(), Collection[26].Clone(), Collection[27].Clone(), Collection[28].Clone(), Collection[29].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[24].Clone(), Collection[25].Clone(), Collection[26].Clone(), Collection[27].Clone(), Collection[28].Clone(), Collection[29].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[30].Clone(), Collection[31].Clone(), Collection[32].Clone(), Collection[33].Clone(), Collection[34].Clone(), Collection[35].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[30].Clone(), Collection[31].Clone(), Collection[32].Clone(), Collection[33].Clone(), Collection[34].Clone(), Collection[35].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[30].Clone(), Collection[31].Clone(), Collection[32].Clone(), Collection[33].Clone(), Collection[34].Clone(), Collection[35].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[36].Clone(), Collection[37].Clone(), Collection[38].Clone(), Collection[39].Clone(), Collection[40].Clone(), Collection[41].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[36].Clone(), Collection[37].Clone(), Collection[38].Clone(), Collection[39].Clone(), Collection[40].Clone(), Collection[41].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[36].Clone(), Collection[37].Clone(), Collection[38].Clone(), Collection[39].Clone(), Collection[40].Clone(), Collection[41].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[42].Clone(), Collection[43].Clone(), Collection[44].Clone(), Collection[45].Clone(), Collection[46].Clone(), Collection[47].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[42].Clone(), Collection[43].Clone(), Collection[44].Clone(), Collection[45].Clone(), Collection[46].Clone(), Collection[47].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[42].Clone(), Collection[43].Clone(), Collection[44].Clone(), Collection[45].Clone(), Collection[46].Clone(), Collection[47].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[48].Clone(), Collection[49].Clone(), Collection[50].Clone(), Collection[51].Clone(), Collection[52].Clone(), Collection[53].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[48].Clone(), Collection[49].Clone(), Collection[50].Clone(), Collection[51].Clone(), Collection[52].Clone(), Collection[53].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[48].Clone(), Collection[49].Clone(), Collection[50].Clone(), Collection[51].Clone(), Collection[52].Clone(), Collection[53].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[54].Clone(), Collection[55].Clone(), Collection[56].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[54].Clone(), Collection[55].Clone(), Collection[56].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[54].Clone(), Collection[55].Clone(), Collection[56].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[58].Clone()});
        dataLevel.Add(new List<Pokemon>() { Collection[58].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[58].Clone() });

        dataLevel.Add(new List<Pokemon>() { Collection[59].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[59].Clone() });
        dataLevel.Add(new List<Pokemon>() { Collection[59].Clone() });







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
