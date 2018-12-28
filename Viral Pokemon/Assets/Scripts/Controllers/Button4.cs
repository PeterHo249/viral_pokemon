using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button4 : MonoBehaviour
{
    public Button button4;
    public BattleManager battleManager;

    public void handleClick()
    {
        Text text4 = GameObject.Find("Button4").GetComponentInChildren<Text>();
        if (text4.text != "None" && text4.text != "NONE")
        {
            battleManager.IsPlayerTurn = false;

            battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[3].skillPP--;

            battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp -= battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[3].skillPower
                                                                                            + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.attack
                                                                                            - battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.defense;
            if (battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp < 0)
                battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp = 0;

            RectTransform recT = GameObject.Find("HPBarAI").GetComponent<RectTransform>();
            float rate = (float)(battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp) / battleManager.currentMaxHPAI;
            recT.sizeDelta = new Vector2((float)(-638.6 - (1 - rate) * 177.4), recT.sizeDelta.y);

            if (rate <= 0.5 && rate > 0.25)
            {
                Image img = GameObject.Find("HPBarAI").GetComponent<Image>();
                img.color = UnityEngine.Color.yellow;
            }

            if (rate <= 0.25)
            {
                Image img = GameObject.Find("HPBarAI").GetComponent<Image>();
                img.color = UnityEngine.Color.red;
            }

            battleManager.LoadInfoPokemon(battleManager.listPokemonAI[battleManager.currentPokemonAI], 2);

            GameObject.Find("Button1").GetComponentInChildren<Text>().text = "FIGHT";
            GameObject.Find("Button2").GetComponentInChildren<Text>().text = "POKEMON";
            GameObject.Find("Button3").GetComponentInChildren<Text>().text = "ITEM";
            GameObject.Find("Button4").GetComponentInChildren<Text>().text = "NONE";

            battleManager.HandleAIAttack();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        button4 = GameObject.Find("Button4").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button4.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
