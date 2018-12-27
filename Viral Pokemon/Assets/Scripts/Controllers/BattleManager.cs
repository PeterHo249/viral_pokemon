using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{

    // logic
    public List<OwnedPokemon> pokemonsOfPlayer; //Max 6
    public List<OwnedPokemon> pokemonsOfAI; //Max 6
    public OwnedPokemon currentAIPokemon;
    public OwnedPokemon currentPlayerPokemon;
    public int currentMaxHP, currentMaxHPAI;
    public bool IsPlayerTurn;


    // cột j đánh hàng i nhân damge A[i][j]
    public float[,] KyHe = new float[ , ] { {1,1,1,1,1,1,2,1,1,1,1,1,1,0,1,1,1,1},
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


    // UI
    public GameObject PokemonPlayer;
    public GameObject PokemonAI;

    public Text txtName, txtNameAI, txtLevel, txtLevelAI, txtHP, txtHPAI;
    public Button skill1, skill2, skill3, skill4;
    public GameObject move1;

    IEnumerator Waiting(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(1);
        obj.SetActive(false);
    }

    public void LoadInfoPokemon(OwnedPokemon pokemon, int type)
    {   
        // load UI
        if (type == 1)
        {
            PokemonPlayer.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/back/123");
            txtName.text = pokemon.samplePokemon.pokemonName;
            txtLevel.text = "lv" + pokemon.level.ToString();
            txtHP.text = pokemon.samplePokemon.hp.ToString() + "/" + currentMaxHP.ToString();
            skill1.GetComponentInChildren<Text>().text = pokemon.samplePokemon.pokemonSkill[0].skillName + ": " 
                                                         + pokemon.samplePokemon.pokemonSkill[0].skillPP.ToString() + ", "
                                                         + pokemon.samplePokemon.pokemonSkill[0].skillType.ToString();
            if (pokemon.samplePokemon.pokemonSkill.Count > 1)
                skill2.GetComponentInChildren<Text>().text = pokemon.samplePokemon.pokemonSkill[1].skillName + ": "
                                                         + pokemon.samplePokemon.pokemonSkill[1].skillPP.ToString();
            if (pokemon.samplePokemon.pokemonSkill.Count > 2)
                skill3.GetComponentInChildren<Text>().text = pokemon.samplePokemon.pokemonSkill[2].skillName + ": "
                                                         + pokemon.samplePokemon.pokemonSkill[2].skillPP.ToString();
            if (pokemon.samplePokemon.pokemonSkill.Count > 3)
                skill4.GetComponentInChildren<Text>().text = pokemon.samplePokemon.pokemonSkill[3].skillName + ": "
                                                         + pokemon.samplePokemon.pokemonSkill[3].skillPP.ToString();
       
        }
        else
        {
            PokemonAI.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/front/89");
            txtNameAI.text = pokemon.samplePokemon.pokemonName;
            txtLevelAI.text = "lv" + pokemon.level.ToString();
            txtHPAI.text = pokemon.samplePokemon.hp.ToString() + "/" + currentMaxHPAI.ToString();
        }
    }

    public void HanldeButton1Click()
    {
        StartCoroutine(Waiting(move1));
        currentPlayerPokemon.samplePokemon.pokemonSkill[0].skillPP--;
        if (currentPlayerPokemon.samplePokemon.pokemonSkill[0].skillPP == 0)
            skill1.interactable = false;
        // Xử lý trừ máu
        currentAIPokemon.samplePokemon.hp -= currentPlayerPokemon.samplePokemon.pokemonSkill[0].skillPower;
        if (currentAIPokemon.samplePokemon.hp < 0)
            currentAIPokemon.samplePokemon.hp = 0;
        float rate = ((float)currentAIPokemon.samplePokemon.hp) / currentMaxHP;
        RectTransform rectT = GameObject.Find("HPBarAI").GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2((float)(-663 - (1-rate) * 153), rectT.sizeDelta.y);

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

        LoadInfoPokemon(currentPlayerPokemon, 1);
        LoadInfoPokemon(currentAIPokemon, 2);
    }

    public void HanldeButton2Click()
    {
        currentPlayerPokemon.samplePokemon.pokemonSkill[1].skillPP--;
        if (currentPlayerPokemon.samplePokemon.pokemonSkill[1].skillPP == 0)
            skill2.interactable = false;

        currentAIPokemon.samplePokemon.hp -= currentPlayerPokemon.samplePokemon.pokemonSkill[1].skillPower;
        if (currentAIPokemon.samplePokemon.hp < 0)
            currentAIPokemon.samplePokemon.hp = 0;
        float rate = ((float)currentAIPokemon.samplePokemon.hp) / currentMaxHP;
        RectTransform rectT = GameObject.Find("HPBarAI").GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2((float)(-663 - (1 - rate) * 153), rectT.sizeDelta.y);

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


        LoadInfoPokemon(currentPlayerPokemon, 1);
        LoadInfoPokemon(currentAIPokemon, 2);
    }

    public void HanldeButton3Click()
    {
        currentPlayerPokemon.samplePokemon.pokemonSkill[2].skillPP--;
        if (currentPlayerPokemon.samplePokemon.pokemonSkill[2].skillPP == 0)
            skill3.interactable = false;

        currentAIPokemon.samplePokemon.hp -= currentPlayerPokemon.samplePokemon.pokemonSkill[2].skillPower;
        if (currentAIPokemon.samplePokemon.hp < 0)
            currentAIPokemon.samplePokemon.hp = 0;
        float rate = ((float)currentAIPokemon.samplePokemon.hp) / currentMaxHP;
        RectTransform rectT = GameObject.Find("HPBarAI").GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2((float)(-663 - (1 - rate) * 153), rectT.sizeDelta.y);

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

        LoadInfoPokemon(currentPlayerPokemon, 1);
        LoadInfoPokemon(currentAIPokemon, 2);
    }

    public void HanldeButton4Click()
    {
        currentPlayerPokemon.samplePokemon.pokemonSkill[3].skillPP--;
        if (currentPlayerPokemon.samplePokemon.pokemonSkill[3].skillPP == 0)
            skill4.interactable = false;

        currentAIPokemon.samplePokemon.hp -= currentPlayerPokemon.samplePokemon.pokemonSkill[3].skillPower;
        if (currentAIPokemon.samplePokemon.hp < 0)
            currentAIPokemon.samplePokemon.hp = 0;
        float rate = ((float)currentAIPokemon.samplePokemon.hp) / currentMaxHP;
        RectTransform rectT = GameObject.Find("HPBarAI").GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2((float)(-663 - (1 - rate) * 153), rectT.sizeDelta.y);

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

        LoadInfoPokemon(currentPlayerPokemon, 1);
        LoadInfoPokemon(currentAIPokemon, 2);
    }

    public void HandleAIAttack()
    {
        // Xử lý skill, máu
        // Xử lý effect
        // Xử lý attack
    }

    // Start is called before the first frame update
    void Start()
    {

        //PokemonAI.SetActive(false);
        //Text t = GameObject.Find("txtName").GetComponent<Text>();
        //t.text = "abc";
        //skill1.GetComponentInChildren<Text>().text = "abc";
        //skill1.interactable = false;
        //Image img = GameObject.Find("HPBar").GetComponent<Image>();
        //img.color = UnityEngine.Color.red;
        //RectTransform rectT = GameObject.Find("HPBar").GetComponent<RectTransform>();
        //rectT.sizeDelta = new Vector2(rectT.sizeDelta.x - 20f, rectT.sizeDelta.y);  

        move1 = GameObject.Find("Move1/8_0");
        move1.SetActive(false);



        currentPlayerPokemon = new OwnedPokemon(new SamplePokemon("ivysaur", 100, 100, 100, 100, 100, 100), 20, 20);
        currentPlayerPokemon.samplePokemon.pokemonSkill.Add(new PokemonSkill("Fire Blast", PokemonType.Fire, 12, 100, 5, "abc"));
        currentPlayerPokemon.samplePokemon.pokemonSkill.Add(new PokemonSkill("Thunder", PokemonType.Fire, 15, 100, 5, "abc"));

        currentAIPokemon = new OwnedPokemon(new SamplePokemon("ivysaur", 100, 100, 100, 100, 100, 100), 20, 20);


        currentMaxHP = currentPlayerPokemon.samplePokemon.hp;
        currentMaxHPAI = currentAIPokemon.samplePokemon.hp;

        // Mapping UI
        PokemonPlayer = (GameObject)Instantiate(Resources.Load("Prefabs/PokemonBack"));
        PokemonAI = (GameObject)Instantiate(Resources.Load("Prefabs/PokemonFront"));

        txtName = GameObject.Find("txtName").GetComponent<Text>();
        txtNameAI = GameObject.Find("txtNameAI").GetComponent<Text>();
        txtLevel = GameObject.Find("txtLevel").GetComponent<Text>();
        txtLevelAI = GameObject.Find("txtLevelAI").GetComponent<Text>();
        txtHP = GameObject.Find("txtHP").GetComponent<Text>();
        txtHPAI = GameObject.Find("txtHPAI").GetComponent<Text>();

        skill1 = GameObject.Find("Skill1").GetComponent<Button>();
        skill2 = GameObject.Find("Skill2").GetComponent<Button>();
        skill3 = GameObject.Find("Skill3").GetComponent<Button>();
        skill4 = GameObject.Find("Skill4").GetComponent<Button>();
        
        if (currentPlayerPokemon.samplePokemon.pokemonSkill.Count == 1)
        {
            skill2.interactable = false;
            skill3.interactable = false;
            skill4.interactable = false;
        }
        if (currentPlayerPokemon.samplePokemon.pokemonSkill.Count == 2)
        {
            skill3.interactable = false;
            skill4.interactable = false;
        }
        if (currentPlayerPokemon.samplePokemon.pokemonSkill.Count == 3)
        {
            skill4.interactable = false;
        }

        // Load UI
        LoadInfoPokemon(currentPlayerPokemon, 1);
        LoadInfoPokemon(currentAIPokemon, 2);

        // Listener
        skill1.onClick.AddListener(HanldeButton1Click);
        skill2.onClick.AddListener(HanldeButton2Click);
        skill3.onClick.AddListener(HanldeButton3Click);
        skill4.onClick.AddListener(HanldeButton4Click);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
