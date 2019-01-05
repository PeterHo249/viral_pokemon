using Mono.Data.SqliteClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static int level;

    public void LoadData()
    {
        string path = "URI=file:" + Application.streamingAssetsPath + "/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;
        IDataReader dbr;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();

        dbcm.CommandText = "select Level from PlayerInfo";
        dbr = dbcm.ExecuteReader();

        while (dbr.Read())
        {
            level = dbr.GetInt32(0);
        }

        dbc.Close();

    }

    public void SaveData()
    {
        string path = "URI=file:" + Application.streamingAssetsPath + "/ViralPokemon.db";
        IDbConnection dbc;
        IDbCommand dbcm;

        dbc = new SqliteConnection(path);
        dbc.Open();
        dbcm = dbc.CreateCommand();

        dbcm.CommandText = "update PlayerInfo set Level = " + level.ToString();
        dbcm.ExecuteScalar();

        dbc.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        SaveData();
    }

    public void SetLevel(int level)
    {
        LevelHandler.level = level;
    }
}
