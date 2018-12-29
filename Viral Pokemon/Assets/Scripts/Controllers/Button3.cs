using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button3 : MonoBehaviour
{

    public Button button3;
    public BattleManager battleManager;
    public int type1, type2;
    public bool IsEffectPlaying;

    public IEnumerator Effect(int type1, int type2)
    {
        if (type1 == 1)
        {
            if (type2 == 1)
            {
                Renderer renderer = battleManager.PokemonPlayer.GetComponent<Renderer>();
                Color newColor = renderer.material.color;
                for (float f = 0; f <= 1f; f += 0.1f)
                {
                    newColor.a = f;
                    renderer.material.color = newColor;
                    yield return new WaitForSeconds(.1f);
                }
                IsEffectPlaying = false;
            }
            if (type2 == 2)
            {
                Renderer renderer = battleManager.PokemonPlayer.GetComponent<Renderer>();
                Color newColor = renderer.material.color;
                for (float f = 1f; f >= 0; f -= 0.1f)
                {
                    newColor.a = f;
                    renderer.material.color = newColor;
                    yield return new WaitForSeconds(.1f);
                }
                IsEffectPlaying = false;
            }
        }
        if (type1 == 2)
        {
            if (type2 == 2)
            {
                Renderer renderer = battleManager.PokemonAI.GetComponent<Renderer>();
                Color newColor = renderer.material.color;
                for (float f = 1f; f >= 0; f -= 0.1f)
                {
                    newColor.a = f;
                    renderer.material.color = newColor;
                    yield return new WaitForSeconds(.1f);
                }
                IsEffectPlaying = false;
            }
            if (type2 == 3)
            {
                Renderer renderer = battleManager.PokemonAI.GetComponent<Renderer>();
                renderer.material.color = Color.red;
                yield return new WaitForSeconds(0.01f);
                renderer.material.color = Color.white;
                IsEffectPlaying = false;
            }
        }
    }

    public void handleClick()
    {
        Text text3 = GameObject.Find("Button3").GetComponentInChildren<Text>();
        if (text3.text == "ITEM")
        {
            battleManager.backgroundMenu2.SetActive(true);
            battleManager.buttonMenu1.SetActive(true);
            battleManager.buttonMenu2.SetActive(true);

            List<GameObject> listsItem = new List<GameObject>();
            listsItem.Add(new GameObject());
            listsItem.Add(new GameObject());
            float y = 3.88f;

            for (int i = 0; i < 2; i++)
            {
                listsItem[i].GetComponent<Transform>().position = new Vector3(1.57f, y - i * 1.1f, 0);
                listsItem[i].GetComponent<Transform>().localScale = new Vector2(1.5f, 1.5f);
                listsItem[i].AddComponent<SpriteRenderer>();
                listsItem[i].GetComponent<SpriteRenderer>().sortingOrder = 4;
                listsItem[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/PokemonFront/3");
            }

            battleManager.buttonMenu1.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // handle item

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);

                for (int i = 0; i < 2; i++)
                {
                    Object.Destroy(listsItem[i]);
                }

            });

            battleManager.buttonMenu2.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // handle item

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);

                for (int i = 0; i < 2; i++)
                {
                    Object.Destroy(listsItem[i]);
                }

            });
        }
        else
        {
            if (text3.text != "None" && text3.text != "NONE")
            {
                battleManager.IsPlayerTurn = false;
                type1 = 2;
                type2 = 3;

                battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[2].skillPP--;

                battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp -= battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[2].skillPower
                                                                                                + battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.attack
                                                                                                - battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.defense;
                if (battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp < 0)
                {
                    battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp = 0;
                    type2 = 2;
                }

                IsEffectPlaying = true;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        button3 = GameObject.Find("Button3").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button3.onClick.AddListener(handleClick);
        type1 = 0;
        type2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEffectPlaying)
        {
            StartCoroutine(Effect(type1, type2));
        }
    }
}
