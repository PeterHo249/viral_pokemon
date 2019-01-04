using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choose1 : MonoBehaviour
{
    // Start is called before the first frame update
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
                battleManager.currentPlayer = battleManager.pokemonsPlayer[0];
                battleManager.LoadUIPokemon(battleManager.currentPlayer, 1);
                battleManager.FadeIn(battleManager.PokemonPlayer);

                battleManager.WaitAI(1);
            }
            battleManager.MenuController(true);
        }
        if (text1.text == "Item List")
        {
            battleManager.MenuChooseController(false, 0);
            battleManager.playerItems[0].amount--;
            if (button.GetComponentInChildren<Text>().text.Contains("Max Potion"))
            {
                battleManager.currentPlayer.currentHp = battleManager.currentPlayer.maxHp;
                battleManager.LoadUIPokemon(battleManager.currentPlayer, 1);

                battleManager.WaitAI(1);
            }
            battleManager.MenuController(true);
        }
        if (text1.text == "Switch pokemon")
        {
            battleManager.playerManager.ownedPokemons[0] = battleManager.pokemonBonus.Clone();
            SceneManager.LoadScene("Level" + LevelHandler.level.ToString());
        }
    }

    void Start()
    {
        button = GameObject.Find("Choose1").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
