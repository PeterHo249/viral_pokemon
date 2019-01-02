using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{

    public List<GameObject> ListPokemon;
    public List<Text> textPokemon;
    public List<Text> amountItems;
    public Text Money;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        GameObject.Find("pokemon1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + player.ownedPokemons[0].id.ToString());
        GameObject.Find("pokemon2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + player.ownedPokemons[1].id.ToString());
        GameObject.Find("pokemon3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + player.ownedPokemons[2].id.ToString());
        GameObject.Find("pokemon4").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + player.ownedPokemons[3].id.ToString());
        GameObject.Find("pokemon5").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + player.ownedPokemons[4].id.ToString());
        GameObject.Find("pokemon6").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Pokemons/front/" + player.ownedPokemons[5].id.ToString());

        GameObject.Find("text1").GetComponentInChildren<Text>().text = player.ownedPokemons[0].pokemonName + " Lv" + player.ownedPokemons[0].level.ToString();
        GameObject.Find("text2").GetComponentInChildren<Text>().text = player.ownedPokemons[1].pokemonName + " Lv" + player.ownedPokemons[1].level.ToString();
        GameObject.Find("text3").GetComponentInChildren<Text>().text = player.ownedPokemons[2].pokemonName + " Lv" + player.ownedPokemons[2].level.ToString();
        GameObject.Find("text4").GetComponentInChildren<Text>().text = player.ownedPokemons[3].pokemonName + " Lv" + player.ownedPokemons[3].level.ToString();
        GameObject.Find("text5").GetComponentInChildren<Text>().text = player.ownedPokemons[4].pokemonName + " Lv" + player.ownedPokemons[4].level.ToString();
        GameObject.Find("text6").GetComponentInChildren<Text>().text = player.ownedPokemons[5].pokemonName + " Lv" + player.ownedPokemons[5].level.ToString();

        GameObject.Find("textItem1").GetComponentInChildren<Text>().text = "Max elixir: " + player.ownedItems[1].amount.ToString();
        GameObject.Find("textItem2").GetComponentInChildren<Text>().text = "Max potion: " + player.ownedItems[0].amount.ToString();

        GameObject.Find("Money").GetComponentInChildren<Text>().text = "$ " + player.Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
