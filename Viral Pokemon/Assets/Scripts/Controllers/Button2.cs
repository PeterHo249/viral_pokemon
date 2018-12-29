﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{

    public Button button2;
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
            if (type2 == 1)
            {
                Renderer renderer = battleManager.PokemonAI.GetComponent<Renderer>();
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
        Text text2 = GameObject.Find("Button2").GetComponentInChildren<Text>();
        if (text2.text == "POKEMON")
        {
            battleManager.backgroundMenu2.SetActive(true);
            battleManager.buttonMenu1.SetActive(true);
            battleManager.buttonMenu2.SetActive(true);
            battleManager.buttonMenu3.SetActive(true);
            battleManager.buttonMenu4.SetActive(true);
            battleManager.buttonMenu5.SetActive(true);

            List<GameObject> listsPokemon = new List<GameObject>();
            for (int i =0; i<5; i++)
            {
                listsPokemon.Add(new GameObject());
            }

            float y = 3.88f;

            for (int i = 0; i < 5; i++)
            {
                listsPokemon[i].GetComponent<Transform>().position = new Vector3(1.57f, y - i*1.1f, 0);
                listsPokemon[i].GetComponent<Transform>().localScale = new Vector2(1.5f, 1.5f);
                listsPokemon[i].AddComponent<SpriteRenderer>();
                listsPokemon[i].GetComponent<SpriteRenderer>().sortingOrder = 4;
                listsPokemon[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/PokemonFront/1");
            }

            battleManager.buttonMenu1.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // switch pokemon

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);
                battleManager.buttonMenu3.SetActive(false);
                battleManager.buttonMenu4.SetActive(false);
                battleManager.buttonMenu5.SetActive(false);

                for (int i =0; i<5; i++)
                {
                    Object.Destroy(listsPokemon[i]);
                }

                type1 = 1;
                type2 = 1;
                IsEffectPlaying = true;
            });

            battleManager.buttonMenu2.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // switch pokemon

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);
                battleManager.buttonMenu3.SetActive(false);
                battleManager.buttonMenu4.SetActive(false);
                battleManager.buttonMenu5.SetActive(false);

                for (int i = 0; i < 5; i++)
                {
                    Object.Destroy(listsPokemon[i]);
                }

                type1 = 1;
                type2 = 1;
                IsEffectPlaying = true;
            });

            battleManager.buttonMenu3.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // switch pokemon

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);
                battleManager.buttonMenu3.SetActive(false);
                battleManager.buttonMenu4.SetActive(false);
                battleManager.buttonMenu5.SetActive(false);

                for (int i = 0; i < 5; i++)
                {
                    Object.Destroy(listsPokemon[i]);
                }

                type1 = 1;
                type2 = 1;
                IsEffectPlaying = true;
            });

            battleManager.buttonMenu4.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // switch pokemon

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);
                battleManager.buttonMenu3.SetActive(false);
                battleManager.buttonMenu4.SetActive(false);
                battleManager.buttonMenu5.SetActive(false);

                for (int i = 0; i < 5; i++)
                {
                    Object.Destroy(listsPokemon[i]);
                }

                type1 = 1;
                type2 = 1;
                IsEffectPlaying = true;
            });

            battleManager.buttonMenu5.GetComponent<Button>().onClick.AddListener(delegate()
            {
                // switch pokemon

                battleManager.backgroundMenu2.SetActive(false);
                battleManager.buttonMenu1.SetActive(false);
                battleManager.buttonMenu2.SetActive(false);
                battleManager.buttonMenu3.SetActive(false);
                battleManager.buttonMenu4.SetActive(false);
                battleManager.buttonMenu5.SetActive(false);

                for (int i = 0; i < 5; i++)
                {
                    Object.Destroy(listsPokemon[i]);
                }

                type1 = 1;
                type2 = 1;
                IsEffectPlaying = true;
            });

        }
        else
        {
            if (text2.text != "None")
            {
                battleManager.IsPlayerTurn = false;
                type1 = 2;
                type2 = 3;

                battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillPP--;

                battleManager.listPokemonAI[battleManager.currentPokemonAI].samplePokemon.hp -= battleManager.listPokemonPlayer[battleManager.currentPokemonPlayer].samplePokemon.pokemonSkill[1].skillPower
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
        button2 = GameObject.Find("Button2").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button2.onClick.AddListener(handleClick);
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