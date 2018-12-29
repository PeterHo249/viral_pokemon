using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public List<OwnedPokemon> listPokemonPlayer = new List<OwnedPokemon>();
    public List<OwnedPokemon> listPokemonAI = new List<OwnedPokemon>();
    public int currentPokemonPlayer = 0, currentPokemonAI = 0;
    public int currentMaxHPPlayer = 0, currentMaxHPAI = 0;
    public bool IsPlayerTurn;
    public int typeEffect, typeObject;


    // UI
    public GameObject PokemonPlayer;
    public GameObject PokemonAI;

    public Text txtInfoAI, txtInfoPlayer, txtHPAI, txtHPPlayer, txtTypeAI, txtTypePlayer;
    public GameObject button1, button2, button3, button4;
    public GameObject backgroundMenu, backgroundMenu2;
    public GameObject buttonMenu1, buttonMenu2, buttonMenu3, buttonMenu4, buttonMenu5;
    public GameObject move;

    public void LoadInfoPokemon(OwnedPokemon pokemon, int type)
    {
        if (type == 1) //load player
        {
            txtInfoPlayer.text = pokemon.samplePokemon.pokemonName + " Lv" + pokemon.level.ToString();
            txtHPPlayer.text = pokemon.samplePokemon.hp.ToString() + "/" + currentMaxHPPlayer;
            if (pokemon.samplePokemon.pokemonType.Count == 2)
            {
                txtTypePlayer.text = pokemon.samplePokemon.pokemonType[0].ToString() + ", "
                                   + pokemon.samplePokemon.pokemonType[1].ToString();
            }
            else
            {
                txtTypePlayer.text = pokemon.samplePokemon.pokemonType[0].ToString();
            }
        }
        else
        {
            txtInfoAI.text = pokemon.samplePokemon.pokemonName + " Lv" + pokemon.level.ToString();
            txtHPAI.text = pokemon.samplePokemon.hp.ToString() + "/" + currentMaxHPPlayer;
            if (pokemon.samplePokemon.pokemonType.Count == 2)
            {
                txtTypeAI.text = pokemon.samplePokemon.pokemonType[0].ToString() + ", "
                                   + pokemon.samplePokemon.pokemonType[1].ToString();
            }
            else
            {
                txtTypeAI.text = pokemon.samplePokemon.pokemonType[0].ToString();
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        IsPlayerTurn = true;
    }

    public IEnumerator Effect(int type1, int type2)
    {
        if (type1 == 1)
        {
            if (type2 == 1)
            {
                Renderer renderer = PokemonPlayer.GetComponent<Renderer>();
                Color newColor = renderer.material.color;
                for (float f = 0; f <= 1f; f += 0.1f)
                {
                    newColor.a = f;
                    renderer.material.color = newColor;
                    yield return new WaitForSeconds(.1f);
                }
            }
            if (type2 == 2)
            {
                Renderer renderer = PokemonPlayer.GetComponent<Renderer>();
                Color newColor = renderer.material.color;
                for (float f = 1f; f >= 0; f -= 0.1f)
                {
                    newColor.a = f;
                    renderer.material.color = newColor;
                    yield return new WaitForSeconds(.1f);
                }
            }
            if (type2 == 3)
            {
                Renderer renderer = PokemonPlayer.GetComponent<Renderer>();
                renderer.material.color = Color.red;
                yield return new WaitForSeconds(0.01f);
                renderer.material.color = Color.white;
            }
        }
        if (type1 == 2)
        {
            if (type2 == 1)
            {
                Renderer renderer = PokemonAI.GetComponent<Renderer>();
                Color newColor = renderer.material.color;
                for (float f = 0; f <= 1f; f += 0.1f)
                {
                    newColor.a = f;
                    renderer.material.color = newColor;
                    yield return new WaitForSeconds(.1f);
                }
            }
        }
    }

    //public IEnumerator FadeOut(GameObject obj)
    //{
    //    Renderer renderer = obj.GetComponent<Renderer>();
    //    Color newColor = renderer.material.color;
    //    for (float f = 1f; f >= 0; f -= 0.1f)
    //    {
    //        newColor.a = f;
    //        renderer.material.color = newColor;
    //        yield return new WaitForSeconds(.1f);
    //    }
    //    IsFadeOutPlaying = false;
    //}

    //public IEnumerator FadeIn(GameObject obj)
    //{
    //    Renderer renderer = obj.GetComponent<Renderer>();
    //    Color newColor = renderer.material.color;
    //    for (float f = 0; f <= 1f; f += 0.1f)
    //    {
    //        newColor.a = f;
    //        renderer.material.color = newColor;
    //        yield return new WaitForSeconds(.1f);
    //    }
    //    IsFadeInPlaying = false;
    //}

    //public IEnumerator Attack(GameObject obj)
    //{
    //    Renderer renderer = obj.GetComponent<Renderer>();
    //    renderer.material.color = Color.red;
    //    yield return new WaitForSeconds(0.01f);
    //    renderer.material.color = Color.white;
    //    IsAttackPlaying = false;
    //}





    public void HandleAIAttack()
    {
        // AI attack
        listPokemonAI[currentPokemonAI].samplePokemon.pokemonSkill[0].skillPP--;

        listPokemonPlayer[currentPokemonPlayer].samplePokemon.hp -= listPokemonAI[currentPokemonAI].samplePokemon.pokemonSkill[0].skillPower
                                                                   + listPokemonAI[currentPokemonAI].samplePokemon.attack
                                                                   - listPokemonPlayer[currentPokemonPlayer].samplePokemon.defense;
        if (listPokemonPlayer[currentPokemonPlayer].samplePokemon.hp < 0)
            listPokemonPlayer[currentPokemonPlayer].samplePokemon.hp = 0;

        float rate = (float)(listPokemonPlayer[currentPokemonPlayer].samplePokemon.hp) / currentMaxHPPlayer;
        RectTransform rectT = GameObject.Find("HPBarPlayer").GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2((float)(-638.6 - (1 - rate) * 177.4), rectT.sizeDelta.y);

        if (rate <= 0.5 && rate > 0.25)
        {
            Image img = GameObject.Find("HPBarPlayer").GetComponent<Image>();
            img.color = UnityEngine.Color.yellow;
        }

        if (rate <= 0.25)
        {
            Image img = GameObject.Find("HPBarPlayer").GetComponent<Image>();
            img.color = UnityEngine.Color.red;
        }

        LoadInfoPokemon(listPokemonPlayer[currentPokemonPlayer], 1);

        StartCoroutine(Waiting());
        StartCoroutine(Effect(1, 3));
    }

    // Start is called before the first frame update
    void Start()
    {
        // Pokemon for test
        OwnedPokemon pokemon1 = new OwnedPokemon(new SamplePokemon("chamander", 100, 100, 100, 100, 100, 40), 20, 20);
        pokemon1.samplePokemon.pokemonSkill.Add(new PokemonSkill("Fire Blast", PokemonType.Fire, 12, 100, 5, "abc"));
        pokemon1.samplePokemon.pokemonSkill.Add(new PokemonSkill("Thunder", PokemonType.Electric, 15, 100, 5, "abc"));
        pokemon1.samplePokemon.pokemonSkill.Add(new PokemonSkill("Bite", PokemonType.Electric, 15, 100, 5, "abc"));
        pokemon1.samplePokemon.pokemonSkill.Add(new PokemonSkill("Pump", PokemonType.Electric, 15, 100, 5, "abc"));
        pokemon1.samplePokemon.pokemonType.Add(PokemonType.Fire);
        listPokemonPlayer.Add(pokemon1);

        OwnedPokemon pokemon2 = new OwnedPokemon(new SamplePokemon("squirtle", 100, 100, 100, 100, 100, 20), 20, 20);
        pokemon2.samplePokemon.pokemonSkill.Add(new PokemonSkill("Fire Blast", PokemonType.Fire, 12, 100, 5, "abc"));
        pokemon2.samplePokemon.pokemonSkill.Add(new PokemonSkill("Thunder", PokemonType.Electric, 15, 100, 5, "abc"));
        pokemon2.samplePokemon.pokemonType.Add(PokemonType.Water);
        pokemon2.samplePokemon.pokemonType.Add(PokemonType.Electric);
        listPokemonAI.Add(pokemon2);

        currentMaxHPPlayer = listPokemonPlayer[0].samplePokemon.hp;
        currentMaxHPAI = listPokemonAI[0].samplePokemon.hp;


        // Load Data
        //listPokemonPlayer = new List<OwnedPokemon>();
        //listPokemonAI = new List<OwnedPokemon>();
        //currentPokemonAI = 0;
        //currentPokemonPlayer = 0;
        //currentMaxHPPlayer = listPokemonPlayer[currentPokemonPlayer].samplePokemon.hp;
        //currentMaxHPAI = listPokemonPlayer[currentPokemonAI].samplePokemon.hp;

        // Mapping
        txtInfoAI = GameObject.Find("TextInfoAI").GetComponent<Text>();
        txtInfoPlayer = GameObject.Find("TextInfoPlayer").GetComponent<Text>();
        txtHPAI = GameObject.Find("TextHPAI").GetComponent<Text>();
        txtHPPlayer = GameObject.Find("TextHPPlayer").GetComponent<Text>();
        txtTypeAI = GameObject.Find("TypeAI").GetComponent<Text>();
        txtTypePlayer = GameObject.Find("TypePlayer").GetComponent<Text>();

        button1 = GameObject.Find("Button1");
        button2 = GameObject.Find("Button2");
        button3 = GameObject.Find("Button3");
        button4 = GameObject.Find("Button4");
        backgroundMenu = GameObject.Find("BackgroundInfoMenu");

        backgroundMenu2 = GameObject.Find("BackgroundInfo");
        buttonMenu1 = GameObject.Find("ButtonMenu1");
        buttonMenu2 = GameObject.Find("ButtonMenu2");
        buttonMenu3 = GameObject.Find("ButtonMenu3");
        buttonMenu4 = GameObject.Find("ButtonMenu4");
        buttonMenu5 = GameObject.Find("ButtonMenu5");

        PokemonPlayer = GameObject.Find("PokemonPlayer");
        PokemonAI = GameObject.Find("PokemonAI");


        // Load first Pokemon
        LoadInfoPokemon(listPokemonPlayer[currentPokemonPlayer], 1);
        LoadInfoPokemon(listPokemonAI[currentPokemonAI], 2);

        // Check turn
        int speedAI = 0, speedPlayer = 0;
        for (int i = 0; i < listPokemonAI.Count; i++)
        {
            speedAI += listPokemonAI[i].samplePokemon.speed;
        }
        for (int i = 0; i < listPokemonPlayer.Count; i++)
        {
            speedPlayer += listPokemonPlayer[i].samplePokemon.speed;
        }

       
        if (speedPlayer >= speedAI)
            IsPlayerTurn = true;
        else
            IsPlayerTurn = false;

        // Check UI
        if (!IsPlayerTurn)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            backgroundMenu.SetActive(false);
        }

        backgroundMenu2.SetActive(false);
        buttonMenu1.SetActive(false);
        buttonMenu2.SetActive(false);
        buttonMenu3.SetActive(false);
        buttonMenu4.SetActive(false);
        buttonMenu5.SetActive(false);

        StartCoroutine(Effect(1, 1));
        StartCoroutine(Effect(2, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerTurn)
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button4.SetActive(true);
            backgroundMenu.SetActive(true);
        }
        else
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            backgroundMenu.SetActive(false);
        }
    }
}
