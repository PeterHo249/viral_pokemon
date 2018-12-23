using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public List<OwnedPokemon> pokemonsOfPlayer; //Max 6
    public List<OwnedPokemon> pokemonsOfAI; //Max 6
    public OwnedPokemon currentAIPokemon;
    public OwnedPokemon currentPlayerPokemon;
    public bool IsPlayerTurn; 

    public void SetupForBattle()
    {
        // clone 6 pokemon của người chơi
        // clone 6 pokemon AI
        // So sánh speed để chọn IsPlayerTurn
    }

    public void BattleFighting()
    {
        // Code đánh nhau
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupForBattle();
    }

    // Update is called once per frame
    void Update()
    {
        BattleFighting();
    }
}
