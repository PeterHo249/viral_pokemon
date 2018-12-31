using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public List<Pokemon> pokemonsPlayer;
    public List<Pokemon> pokemonsAI;
    public List<Item> playerItems;
    public Pokemon currentPlayer, currentAI;
    public bool IsPlayerTurn;
    public Player playerManager;


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


    public void LoadData()
    {
        playerManager = FindObjectOfType<Player>();
        pokemonsPlayer = new List<Pokemon>(playerManager.ownedPokemons);
        pokemonsAI = new List<Pokemon>(playerManager.ownedPokemons);



        //Pokemon pokemon = new Pokemon(1, "Bulbasuar", 45, 49, 49, 45, 1);
        //pokemon.skills.Add(new PokemonSkill(1, "Posion", 8, 10, 30));
        //pokemon.skills.Add(new PokemonSkill(2, "Seed", 5, 5, 30));
        //pokemon.type.Add(5);
        //pokemon.type.Add(8);

        //Pokemon pokemon1 = new Pokemon(1, "Bulbasuar", 45, 49, 49, 45, 1);
        //pokemon1.skills.Add(new PokemonSkill(1, "Posion", 8, 10, 30));
        //pokemon1.skills.Add(new PokemonSkill(2, "Seed", 5, 5, 30));
        //pokemon1.type.Add(5);
        //pokemon1.type.Add(8);

        //Pokemon pokemon2 = new Pokemon(4, "Charmander", 39, 52, 43, 65, 1);
        //pokemon2.skills.Add(new PokemonSkill(3, "Fire burn", 2, 10, 30));
        //pokemon2.skills.Add(new PokemonSkill(4, "Fire blast", 2, 100, 5));
        //pokemon2.type.Add(2);

        //Pokemon pokemon3 = new Pokemon(4, "Charmander", 39, 52, 43, 65, 1);
        //pokemon3.skills.Add(new PokemonSkill(3, "Fire burn", 2, 10, 30));
        //pokemon3.skills.Add(new PokemonSkill(4, "Fire blast", 2, 100, 5));
        //pokemon3.type.Add(2);

        //pokemonsPlayer.Add(pokemon);
        //pokemonsPlayer.Add(pokemon2);
        //pokemonsAI.Add(pokemon1);
        //pokemonsAI.Add(pokemon3);

        currentAI = pokemonsAI[0];
        currentPlayer = pokemonsPlayer[0];

        playerItems = new List<Item>();
        playerItems.Add(new Item(1, "Max Potion", 1));
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

        Moves.Add(GameObject.Find("2_0"));

        BallPlayer = GameObject.Find("BallPlayer");
        BallAI = GameObject.Find("BallAI");
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
            HPBarPlayer.sizeDelta = new Vector2((float)(-595.7 - (1-rate)*208.3),HPBarPlayer.sizeDelta.y);
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
            HPBarAI.sizeDelta = new Vector2((float)(-595.7 - (1 - rate) * 208.3), HPBarAI.sizeDelta.y);
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

    public void HandleAIAttack()
    {
        if (currentAI.currentHp > 0)
        {
            currentPlayer.currentHp -= currentAI.skills[0].power
                         + currentAI.attack
                         - currentPlayer.defense;
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

    public IEnumerator _DownHP(RectTransform recT, float to, float max)
    {
        while (recT.rect.width > to)
        {
            recT.sizeDelta = new Vector2(recT.sizeDelta.x - 1, recT.sizeDelta.y);
            yield return new WaitForSeconds(.0001f);
        }
    }

    public void DownHP(RectTransform rect, float to, float max)
    {
        StartCoroutine(_DownHP(rect, to, max));
    }

    public IEnumerator _EffectAttack(int type)
    {
        if (type == 1)
        {
            Moves[0].GetComponent<Transform>().localScale = new Vector3(5, 5, 0);
            Moves[0].SetActive(true);
            yield return new WaitForSeconds(1);
            Moves[0].SetActive(false);
        }
        if (type == 2)
        {
            Moves[0].GetComponent<Transform>().localScale = new Vector3(-5, -5, 0);
            Moves[0].SetActive(true);
            yield return new WaitForSeconds(1);
            Moves[0].SetActive(false);
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

        LoadUIPokemon(currentPlayer, 1);
        LoadUIPokemon(currentAI, 2);
        FadeIn(PokemonPlayer);
        FadeIn(PokemonAI);

        Moves[0].SetActive(false);

        BallAI.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/ball")[pokemonsAI.Count - 1];
        BallPlayer.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/ball")[pokemonsPlayer.Count - 1];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
