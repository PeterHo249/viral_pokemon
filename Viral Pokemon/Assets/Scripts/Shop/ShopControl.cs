using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{

    public int priceMaxElixir;
    public int priceMaxPotion;

    public Text moneyAmountText;
    public Text amountItem1Text;

    public Button buyButton1;
    public Button buyButton2;

    public Player playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<Player>();
        priceMaxElixir = 100;
        priceMaxPotion = 200;

        moneyAmountText = GameObject.Find("Money").GetComponent<Text>();
        amountItem1Text = GameObject.Find("Data").GetComponent<Text>();

        buyButton1 = GameObject.Find("Item1_Button").GetComponent<Button>();
        buyButton2 = GameObject.Find("Item2_Button").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = playerManager.Money.ToString();

        if (playerManager.Money >= 100)
        {
            buyButton1.interactable = true;
        }
        else
            buyButton1.interactable = false;

        if (playerManager.Money >= 200)
        {
            buyButton2.interactable = true;
        }
        else
            buyButton2.interactable = false;
    }



    public void buyItem1()
    {
        playerManager.Money -= 100;
        playerManager.ownedItems[1].amount++;
        moneyAmountText.text = playerManager.Money.ToString();
        amountItem1Text.text = "x " + playerManager.ownedItems[1].amount.ToString();
    }

    public void buyItem2()
    {
        playerManager.Money -= 200;
        playerManager.ownedItems[0].amount++;
        moneyAmountText.text = playerManager.Money.ToString();
        amountItem1Text.text = "x " + playerManager.ownedItems[0].amount.ToString();
    }
}
