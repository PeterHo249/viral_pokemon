using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choose3 : MonoBehaviour
{
    public Button button;
    public BattleManager battleManager;

    public void handleClick()
    {
        Text text1 = GameObject.Find("MenuChooseInfo").GetComponent<Text>();
        if (text1.text == "Pokemon List")
        {
            battleManager.MenuChooseController(false, 0);
            if (button.GetComponentInChildren<Text>().text.Contains(battleManager.currentPlayer.pokemonName))
            {

            }
            else
            {
                battleManager.currentPlayer = battleManager.pokemonsPlayer[2];
                battleManager.LoadUIPokemon(battleManager.currentPlayer, 1);
                battleManager.FadeIn(battleManager.PokemonPlayer);

                battleManager.WaitAI(1);
            }
        }
        if (text1.text == "Item List")
        {
            battleManager.MenuChooseController(false, 0);
            battleManager.playerItems[2].amount--;
            if (button.GetComponentInChildren<Text>().text.Contains("Max Potion"))
            {
                battleManager.currentPlayer.currentHp = battleManager.currentPlayer.maxHp;
                battleManager.LoadUIPokemon(battleManager.currentPlayer, 1);

                battleManager.WaitAI(1);
            }
        }
    }

    void Start()
    {
        button = GameObject.Find("Choose3").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
