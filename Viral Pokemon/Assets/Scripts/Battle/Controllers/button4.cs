using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button4 : MonoBehaviour
{
    public Button button;
    public BattleManager battleManager;

    public void handleClick()
    {
        Text text1 = button.GetComponentInChildren<Text>();
        if (text1.text != "None")
        {

            battleManager.currentPlayer.skills[3].pp--;
            double hp = (battleManager.currentPlayer.skills[3].power + battleManager.currentPlayer.attack - battleManager.currentAI.defense) * BattleManager.KyHe[battleManager.currentAI.type[0] - 1, battleManager.currentPlayer.skills[3].type - 1];

            if (hp <= 0)
                hp = 1;

            hp = Math.Round(hp, 0);

            battleManager.currentAI.currentHp -= (int)hp;
            if (battleManager.currentAI.currentHp < 0)
            {
                battleManager.FadeOut(battleManager.PokemonAI);
                battleManager.currentAI.currentHp = 0;
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

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button4").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
