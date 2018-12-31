using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    static int sumMoney;
    static int maxAmount = 10;
    static int amount;

    public Text moneyAmountText;
    public Text AmoutItem;
    public Text moneyItem;
    public Button buyButton;

    // Start is called before the first frame update
    void Start()
    {

        sumMoney = 1000000;
        amount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = sumMoney.ToString();

        if (sumMoney >= 100)
            buyButton.interactable = true;
        else
            buyButton.interactable = false;
    }



    public void buyItem()
    {
        sumMoney -= 100*amount;
        moneyAmountText.text = sumMoney.ToString();
    }

    public void Up()
    {
        if (amount < maxAmount)
        {
            amount += 1;
            AmoutItem.text = amount.ToString();
            moneyItem.text = (amount * 100).ToString();
        }
        if(amount * 100 < sumMoney)
            buyButton.interactable = false;
    }

    public void Down()
    {
        if (amount > 0)
        {
            amount -= 1;
            AmoutItem.text = amount.ToString();
            moneyItem.text = (amount * 100).ToString();
        }
        if (amount * 100 < sumMoney)
            buyButton.interactable = false;
    }
}
