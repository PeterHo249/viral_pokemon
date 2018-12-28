using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    public Button button1;
    public BattleManager battleManager;


    
    public void handleClick()
    {
        Text text1 = GameObject.Find("Button1").GetComponentInChildren<Text>();
        if (text1.text == "FIGHT")
        {
            switch (battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill.Count)
            {
                case 1:
                    GameObject.Find("Button1").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillName
                                                                                     + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillPP.ToString();
                    //GameObject.Find("Button2").GetComponent<Button>().interactable = false;
                    GameObject.Find("Button2").GetComponentInChildren<Text>().text = "None";
                    //GameObject.Find("Button3").GetComponent<Button>().interactable = false;
                    GameObject.Find("Button3").GetComponentInChildren<Text>().text = "None";
                    //GameObject.Find("Button4").GetComponent<Button>().interactable = false;
                    GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";
                    break;
                case 2:
                    GameObject.Find("Button1").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillName
                                                                                     + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillPP.ToString();
                    GameObject.Find("Button2").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillName
                                                                                     + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillPP.ToString();
                    GameObject.Find("Button3").GetComponentInChildren<Text>().text = "None";
                    //GameObject.Find("Button3").GetComponent<Button>().interactable = false;
                    GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";
                    //GameObject.Find("Button4").GetComponent<Button>().interactable = false;
                    break;
                case 3:
                    GameObject.Find("Button1").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillName
                                                                                     + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillPP.ToString();
                    GameObject.Find("Button2").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillName
                                                                                      + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillPP.ToString();
                    GameObject.Find("Button3").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[2].skillName
                                                                                      + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[2].skillPP.ToString();
                    GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";
                    //GameObject.Find("Button4").GetComponent<Button>().interactable = false;
                    break;

                case 4:
                    GameObject.Find("Button1").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillName
                                                                                    + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillPP.ToString();
                    GameObject.Find("Button2").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillName
                                                                                    + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillPP.ToString();
                    GameObject.Find("Button3").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[2].skillName
                                                                                    + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[2].skillPP.ToString();
                    GameObject.Find("Button4").GetComponentInChildren<Text>().text = battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[3].skillName
                                                                                    + " " + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[3].skillPP.ToString();
                    break;
            }
        }
        else
        {
            battleManager.IsPlayerTurn = false;
  
            battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillPP--;

            battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp -= battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[0].skillPower 
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
        button1 = GameObject.Find("Button1").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button1.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
