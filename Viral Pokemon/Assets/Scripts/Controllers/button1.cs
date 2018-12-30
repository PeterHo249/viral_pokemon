using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button1 : MonoBehaviour
{
    public Button button;
    public BattleManager battleManager;

    public void handleClick()
    {
        Text text1 = button.GetComponentInChildren<Text>();
        if (text1.text == "Fight")
        {
            int i = battleManager.currentPlayer.skills.Count;
            if (i == 1)
            {
                button.GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[0].skillName + " " + battleManager.currentPlayer.skills[0].pp.ToString();
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "None";
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "None";
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";
            }
            if (i == 2)
            {
                button.GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[0].skillName + " " + battleManager.currentPlayer.skills[0].pp.ToString();
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[1].skillName + " " + battleManager.currentPlayer.skills[1].pp.ToString();
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "None";
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";

            }
            if (i == 3)
            {
                button.GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[0].skillName + " " + battleManager.currentPlayer.skills[0].pp.ToString();
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[1].skillName + " " + battleManager.currentPlayer.skills[1].pp.ToString();
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[2].skillName + " " + battleManager.currentPlayer.skills[2].pp.ToString();
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";

            }
            if (i == 4)
            {
                button.GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[0].skillName + " " + battleManager.currentPlayer.skills[0].pp.ToString();
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[1].skillName + " " + battleManager.currentPlayer.skills[1].pp.ToString();
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[2].skillName + " " + battleManager.currentPlayer.skills[2].pp.ToString();
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = battleManager.currentPlayer.skills[3].skillName + " " + battleManager.currentPlayer.skills[3].pp.ToString();
            }

        }
        else
        {
            if (text1.text != "None")
            {

                battleManager.currentPlayer.skills[0].pp--;
                battleManager.currentAI.currentHp -= battleManager.currentPlayer.skills[0].power
                                                   + battleManager.currentPlayer.attack
                                                   - battleManager.currentAI.defense;
                if (battleManager.currentAI.currentHp < 0)
                {
                    battleManager.currentAI.currentHp = 0;
                    battleManager.FadeOut(battleManager.PokemonAI);
                }

                battleManager.LoadUIPokemon(battleManager.currentAI, 2);
                battleManager.Attack(battleManager.PokemonAI);
                battleManager.EffectAttack(1);

                GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Fight";
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Pokemon";
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Item";
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = "None";

                battleManager.WaitAI(2);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button1").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
