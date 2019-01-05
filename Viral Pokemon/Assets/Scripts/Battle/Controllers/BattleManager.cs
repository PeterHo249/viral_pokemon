using Mono.Data.SqliteClient;
using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public List<Pokemon> pokemonsPlayer;
    public List<Pokemon> pokemonsAI;
    public List<Item> playerItems;
    public Pokemon currentPlayer, currentAI;
    public bool IsPlayerTurn;
    public Player playerManager;
    public Pokemon pokemonBonus;


    // UI
    public GameObject PokemonAI, PokemonPlayer;
    public Text txtNameAI, txtNamePlayer, txtLevelAI, txtLevelPlayer, txtHPAI, txtHPPlayer;
    public RectTransform HPBarAI, HPBarPlayer;

    public GameObject MenuChoose;
    public GameObject MenuChooseInfo;
    public List<GameObject> Chooses;
    public List<GameObject> SpriteChooses;

    public List<GameObject> Moves;

    public GameObject BallPlayer;
    public GameObject BallAI;

    public GameObject BonusBackground, PokemonBonus, TextBonus;

    public List<Pokemon> clone;

    //Sounds
    public AudioClip play;
    public AudioClip win;

    private AudioSource audioSource;

    // cột j đánh hàng i nhân damge A[i][j]
    public static double[,] KyHe = new double[,] { {1,1,1,1,1,1,2,1,1,1,1,1,1,0,1,1,1,1},
                                            {1,0.5f,2,1,0.5f,0.5f,1,1,2,1,1,0.5f,2,1,1,1,0.5f,0.5f},
                                            {1,0.5f,0.5f,2,2,0.5f,1,1,1,1,1,1,1,1,1,1,0.5f,1},
                                            {1,1,1,0.5f,1,1,1,1,2,0.5f,1,1,1,1,1,1,0.5f,1},
                                            {1,2,0.5f,0.5f,0.5f,2,1,2,0.5f,2,1,2,1,1,1,1,1,1},
                                            {1,2,1,1,1,0.5f,2,1,1,1,1,1,2,1,1,1,2,1},
                                            {1,1,1,1,1,1,1,1,1,2,2,0.5f,0.5f,1,1,0.5f,1,2},
                                            {1,1,1,1,0.5f,1,0.5f,0.5f,2,1,2,0.5f,1,1,1,1,1,0.5f},
                                            {1,1,2,0,2,2,1,0.5f,1,1,1,1,0.5f,1,1,1,1,1},
                                            {1,1,1,2,0.5f,2,0.5f,1,0,1,1,0.5f,2,1,1,1,1,1},
                                            {1,1,1,1,1,1,0.5f,1,1,1,0.5f,2,1,2,1,2,1,1},
                                            {1,2,1,1,0.5f,1,0.5f,1,0.5f,2,1,1,2,1,1,1,1,1},
                                            {0.5f,0.5f,2,1,2,1,2,0.5f,2,0.5f,1,1,1,1,1,1,2,1},
                                            {0,1,1,1,1,1,0,0.5f,1,1,1,0.5f,1,2,1,2,1,1},
                                            {1,0.5f,0.5f,0.5f,0.5f,2,1,1,1,1,1,1,1,1,2,1,1,2},
                                            {1,1,1,1,1,1,2,1,1,1,0,2,1,0.5f,1,0.5f,1,2},
                                            {0.5f,2,1,1,0.5f,0.5f,2,0,2,0.5f,0.5f,0.5f,0.5f,1,0.5f,1,0.5f,0.5f},
                                            {1,1,1,1,1,1,0.5f,2,1,1,1,0.5f,1,1,0,0.5f,2,1}};


    public void LoadData()
    {
        playerManager = FindObjectOfType<Player>();

        pokemonsPlayer = new List<Pokemon>();
        for (int i = 0; i < playerManager.ownedPokemons.Count; i++)
        {
            pokemonsPlayer.Add(playerManager.ownedPokemons[i].Clone());
        }

        pokemonsAI = TalkObstacle.fetch;

        currentAI = pokemonsAI[0];
        currentPlayer = pokemonsPlayer[0];



        playerItems = new List<Item>();
        playerItems = playerManager.ownedItems;

        clone = new List<Pokemon>();
        for(int i = 0; i < pokemonsAI.Count; i++)
        {
            clone.Add(pokemonsAI[i].Clone());
        }
    }

    public void MappingUI()
    {
        PokemonPlayer = GameObject.Find("PokemonPlayer");
        PokemonAI = GameObject.Find("PokemonAI");

        txtNameAI = GameObject.Find("TextNamePokemonAI").GetComponent<Text>();
        txtNamePlayer = GameObject.Find("TextNamePokemonPlayer").GetComponent<Text>();
        txtLevelAI = GameObject.Find("TextLevelPokemonAI").GetComponent<Text>();
        txtLevelPlayer = GameObject.Find("TextLevelPokemonPlayer").GetComponent<Text>();
        txtHPAI = GameObject.Find("TextHPAI").GetComponent<Text>();
        txtHPPlayer = GameObject.Find("TextHPPlayer").GetComponent<Text>();

        HPBarAI = GameObject.Find("HPBarAI").GetComponent<RectTransform>();
        HPBarPlayer = GameObject.Find("HPBarPlayer").GetComponent<RectTransform>();

        MenuChoose = GameObject.Find("MenuChoose");
        Chooses = new List<GameObject>();
        for (int i = 1; i <= 6; i++)
        {
            GameObject obj = GameObject.Find("Choose" + i.ToString());
            Chooses.Add(obj);
        }
        SpriteChooses = new List<GameObject>();
        for (int i = 1; i <= 6; i++)
        {
            GameObject obj = GameObject.Find("Sprite" + i.ToString());
            SpriteChooses.Add(obj);
        }
        MenuChooseInfo = GameObject.Find("MenuChooseInfo");

        Moves.Add(GameObject.Find("1_0"));
        Moves.Add(GameObject.Find("2_0"));
        Moves.Add(GameObject.Find("3_0"));
        Moves.Add(GameObject.Find("4_0"));

        BallPlayer = GameObject.Find("BallPlayer");
        BallAI = GameObject.Find("BallAI");

        BonusBackground = GameObject.Find("BonusBackground");
        PokemonBonus = GameObject.Find("PokemonBonus");
        TextBonus = GameObject.Find("TextBonus");
    }

    public void LoadUIPokemon(Pokemon pokemon, int type)
    {
        if (type == 1)
        {
            txtNamePlayer.text = pokemon.pokemonName;
            txtLevelPlayer.text = "Lv" + pokemon.level.ToString();
            txtHPPlayer.text = pokemon.currentHp + "/" + pokemon.maxHp;

            PokemonPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite>("Sprites/Pokemons/back/" + pokemon.id.ToString());

            float rate = (float)(pokemon.currentHp) / pokemon.maxHp;
            HPBarPlayer.sizeDelta = new Vector2((float)(-617 - (1 - rate) * 196), HPBarPlayer.sizeDelta.y);
            if (rate > 0.5)
            {
                HPBarPlayer.GetComponent<Image>().color = Color.green;
            }
            if (rate <= 0.5 && rate > 0.25)
            {
                HPBarPlayer.GetComponent<Image>().color = Color.yellow;
            }
            if (rate <= 0.25)
            {
                HPBarPlayer.GetComponent<Image>().color = Color.red;
            }

        }
        if (type == 2)
        {
            txtNameAI.text = pokemon.pokemonName;
            txtLevelAI.text = "Lv" + pokemon.level.ToString();
            txtHPAI.text = pokemon.currentHp + "/" + pokemon.maxHp;

            PokemonAI.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + pokemon.id.ToString());

            float rate = (float)(pokemon.currentHp) / pokemon.maxHp;
            HPBarAI.sizeDelta = new Vector2((float)(-617 - (1 - rate) * 196), HPBarAI.sizeDelta.y);
            if (rate > 0.5)
            {
                HPBarAI.GetComponent<Image>().color = Color.green;
            }
            if (rate <= 0.5 && rate > 0.25)
            {
                HPBarAI.GetComponent<Image>().color = Color.yellow;
            }
            if (rate <= 0.25)
            {
                HPBarAI.GetComponent<Image>().color = Color.red;
            }
        }



    }

    public void MenuController(bool IsShow)
    {
        if (IsShow)
        {
            GameObject.Find("Button1").GetComponent<Button>().interactable = true;
            GameObject.Find("Button2").GetComponent<Button>().interactable = true;
            GameObject.Find("Button3").GetComponent<Button>().interactable = true;
            GameObject.Find("Button4").GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("Button1").GetComponent<Button>().interactable = false;
            GameObject.Find("Button2").GetComponent<Button>().interactable = false;
            GameObject.Find("Button3").GetComponent<Button>().interactable = false;
            GameObject.Find("Button4").GetComponent<Button>().interactable = false;
        }
    }

    public void MenuChooseController(bool IsShow, int type)
    {
        if (IsShow)
        {
            if (type == 1)
            {
                MenuChooseInfo.SetActive(true);
                MenuChoose.SetActive(true);
                MenuChooseInfo.GetComponent<Text>().text = "Pokemon List";
                int i = 0;
                while (i < pokemonsPlayer.Count)
                {
                    SpriteChooses[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + pokemonsPlayer[i].id.ToString());
                    Chooses[i].GetComponentInChildren<Text>().text = pokemonsPlayer[i].pokemonName + " " + pokemonsPlayer[i].level.ToString();
                    SpriteChooses[i].SetActive(true);
                    Chooses[i].SetActive(true);
                    i++;
                }
            }
            if (type == 2)
            {
                MenuChooseInfo.SetActive(true);
                MenuChoose.SetActive(true);
                MenuChooseInfo.GetComponent<Text>().text = "Item List";
                int i = 0;
                while (i < playerItems.Count)
                {
                    SpriteChooses[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Items/" + playerItems[i].id.ToString());
                    Chooses[i].GetComponentInChildren<Text>().text = playerItems[i].name + " " + playerItems[i].amount.ToString();
                    SpriteChooses[i].SetActive(true);
                    Chooses[i].SetActive(true);
                    i++;
                }
            }
            if (type == 3)
            {
                MenuChooseInfo.SetActive(true);
                MenuChoose.SetActive(true);
                MenuChooseInfo.GetComponent<Text>().text = "Switch pokemon";
                int i = 0;
                while (i < playerManager.ownedPokemons.Count)
                {
                    SpriteChooses[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + playerManager.ownedPokemons[i].id.ToString());
                    Chooses[i].GetComponentInChildren<Text>().text = playerManager.ownedPokemons[i].pokemonName + " " + playerManager.ownedPokemons[i].level.ToString();
                    SpriteChooses[i].SetActive(true);
                    Chooses[i].SetActive(true);
                    i++;
                }
            }
        }
        else
        {
            MenuChooseInfo.SetActive(false);
            MenuChoose.SetActive(false);
            foreach (GameObject obj in Chooses)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in SpriteChooses)
            {
                obj.SetActive(false);
            }
        }
    }

    public void BonusMenuController(bool IsShow)
    {
        if (IsShow)
        {
            BonusBackground.SetActive(true);
            PokemonBonus.SetActive(true);
            TextBonus.SetActive(true);
        }
        else
        {
            BonusBackground.SetActive(false);
            PokemonBonus.SetActive(false);
            TextBonus.SetActive(false);

        }
    }

    public void Bonus()
    {
        System.Random rnd = new System.Random();
        int k = rnd.Next(0,5);
        pokemonBonus = clone[k];
        pokemonBonus.LevelUp(1);

        PokemonBonus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + pokemonBonus.id.ToString());
        playerManager.Money += 500;

        for (int i = 0; i < playerManager.ownedPokemons.Count; i++ )
        {
            playerManager.ownedPokemons[i].LevelUp(1);
        }

        MenuChooseController(true, 3);
        BonusMenuController(true);
    }

    public void HandleAIAttack()
    {
        if (currentAI.currentHp > 0)
        {
            double hp = (currentAI.skills[0].power + currentAI.attack - currentPlayer.defense) * BattleManager.KyHe[currentPlayer.type[0] - 1, currentAI.skills[0].type - 1];

            if (hp <= 0)
                hp = 1;

            hp = Math.Round(hp, 0);

            Debug.Log(hp);


            currentPlayer.currentHp -= (int) hp;

            if (currentPlayer.currentHp < 0)
            {
                currentPlayer.currentHp = 0;
                FadeOut(PokemonPlayer);
            }

            LoadUIPokemon(currentPlayer, 1);
            Attack(PokemonPlayer);
            EffectAttack(2);
        }
        else
        {
            pokemonsAI.RemoveAt(0);

            if (pokemonsAI.Count == 0)
            {
                BallAI.GetComponent<SpriteRenderer>().sprite = null;
                Debug.Log("AI lose");

                audioSource.clip = win;
                audioSource.Play();

                LevelManager.level++;
                if (LevelManager.level == 3)
                {
                    LevelManager.level = 0;
                    LevelHandler.level++;

                    string path = "URI=file:" + Application.streamingAssetsPath + "/ViralPokemon.db";
                    IDbConnection dbc;
                    IDbCommand dbcm;
                    dbc = new SqliteConnection(path);
                    dbc.Open();
                    dbcm = dbc.CreateCommand();
                    dbcm.CommandText = "update PlayerInfo set Level = " + LevelHandler.level.ToString();
                    dbcm.ExecuteScalar();
                    dbc.Close();

                    Bonus();
                }
                else
                {
                    SceneManager.LoadScene("Level" + LevelHandler.level.ToString());
                }
                
            }
            else
            {
                currentAI = pokemonsAI[0];
                LoadUIPokemon(currentAI, 2);
                FadeIn(PokemonAI);
                BallAI.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/ball")[pokemonsAI.Count - 1];
            }
        }
    }

    public IEnumerator _WaitAI(float i)
    {
        MenuController(false);
        yield return new WaitForSeconds(i);
        HandleAIAttack();
        yield return new WaitForSeconds(i);
        MenuController(true);
        WaitPlayer();
    }

    public void WaitAI(float i)
    {
        StartCoroutine(_WaitAI(i));
    }

    public IEnumerator _WaitPlayer()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < pokemonsPlayer.Count; i++)
        {
            if (currentPlayer.id == pokemonsPlayer[i].id)
            {
                pokemonsPlayer.RemoveAt(i);
                break;
            }
        }
        if (pokemonsPlayer.Count == 0)
        {
            BallPlayer.GetComponent<SpriteRenderer>().sprite = null;
            Debug.Log("Player lose");
            SceneManager.LoadScene("MapScene");
        }
        else
        {
            BallPlayer.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/ball")[pokemonsPlayer.Count - 1];
            MenuController(false);
            MenuChooseController(true, 1);
        }
    }

    public void WaitPlayer()
    {
        if (currentPlayer.currentHp == 0)
        {
            StartCoroutine(_WaitPlayer());
        }

    }

    public IEnumerator _FadeIn(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color newColor = renderer.material.color;
        for (float f = 0; f <= 1f; f += 0.1f)
        {
            newColor.a = f;
            renderer.material.color = newColor;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void FadeIn(GameObject obj)
    {
        StartCoroutine(_FadeIn(obj));
    }

    public IEnumerator _FadeOut(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color newColor = renderer.material.color;
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            newColor.a = f;
            renderer.material.color = newColor;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void FadeOut(GameObject obj)
    {
        StartCoroutine(_FadeOut(obj));
    }

    public IEnumerator _Attack(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = Color.white;
    }

    public void Attack(GameObject obj)
    {
        StartCoroutine(_Attack(obj));
    }

    public IEnumerator _EffectAttack(int type)
    {
        System.Random rnd = new System.Random();
        int i = rnd.Next(0, 3);
        if (type == 1)
        {
            Moves[i].GetComponent<Transform>().localScale = new Vector3(5, 5, 0);
            Moves[i].SetActive(true);
            yield return new WaitForSeconds(1);
            Moves[i].SetActive(false);
        }
        if (type == 2)
        {
            Moves[i].GetComponent<Transform>().localScale = new Vector3(-5, -5, 0);
            Moves[i].SetActive(true);
            yield return new WaitForSeconds(1);
            Moves[i].SetActive(false);
        }
    }

    public void EffectAttack(int type)
    {
        StartCoroutine(_EffectAttack(type));
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        MappingUI();


        MenuChooseController(false, 0);
        BonusMenuController(false);

        LoadUIPokemon(currentPlayer, 1);
        LoadUIPokemon(currentAI, 2);
        FadeIn(PokemonPlayer);
        FadeIn(PokemonAI);

        Moves[0].SetActive(false);
        Moves[1].SetActive(false);
        Moves[2].SetActive(false);
        Moves[3].SetActive(false);

        BallAI.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/ball")[pokemonsAI.Count - 1];
        BallPlayer.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/ball")[pokemonsPlayer.Count - 1];

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = play;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
