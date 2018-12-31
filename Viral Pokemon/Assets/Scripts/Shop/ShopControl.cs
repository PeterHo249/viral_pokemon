using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    static int sumMoney;

    public int priceMaxElixir;
    public int priceMaxPotion;

    public Text moneyAmountText;

    public Button buyButton1;
    public Button buyButton2;

    // Start is called before the first frame update
    void Start()
    {

        sumMoney = 1000;
        priceMaxElixir = 100;
        priceMaxPotion = 200;
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = Player.Money.ToString();

        print(sumMoney);

        if (sumMoney >= 100)
            buyButton1.interactable = true;
        else
            buyButton1.interactable = false;

        if (sumMoney >= 200)
            buyButton2.interactable = true;
        else
            buyButton2.interactable = false;
    }



    public void buyItem1()
    {
        sumMoney -= 100;
        print(sumMoney);
        moneyAmountText.text = sumMoney.ToString();
    }

    public void buyItem2()
    {
        sumMoney -= 200;
        print(sumMoney);
        moneyAmountText.text = sumMoney.ToString();
    }

    //public void Up()
    //{
    //    if (amount < maxAmount)
    //    {
    //        amount += 1;
    //        AmoutItem.text = amount.ToString();
    //        moneyItem.text = (amount * 100).ToString();
    //    }
    //    if(amount * 100 < sumMoney)
    //        buyButton.interactable = false;
    //}

    //public void Down()
    //{
    //    if (amount > 0)
    //    {
    //        amount -= 1;
    //        AmoutItem.text = amount.ToString();
    //        moneyItem.text = (amount * 100).ToString();
    //    }
    //    if (amount * 100 < sumMoney)
    //        buyButton.interactable = false;
    //}
}
