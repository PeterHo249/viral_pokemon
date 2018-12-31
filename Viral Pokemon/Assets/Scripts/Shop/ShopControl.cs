using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    static int sumMoney;
    static int amountItem1;
    static int amountItem2;

    public int priceMaxElixir;
    public int priceMaxPotion;

    public Text moneyAmountText;
    public Text amountItem1Text;
    public Text amountItem2Text;

    public Button buyButton1;
    public Button buyButton2;

    // Start is called before the first frame update
    void Start()
    {

        sumMoney = 10000;
        priceMaxElixir = 100;
        priceMaxPotion = 200;
        amountItem1 = 0;
        amountItem2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = sumMoney.ToString();

        if (sumMoney >= 100)
        {
            buyButton1.interactable = true;
        }
        else
            buyButton1.interactable = false;

        if (sumMoney >= 200)
        {
            buyButton2.interactable = true;
        }
        else
            buyButton2.interactable = false;
    }



    public void buyItem1()
    {
        sumMoney -= 100;
        amountItem1++;
        moneyAmountText.text = sumMoney.ToString();
        amountItem1Text.text = amountItem1.ToString();
    }

    public void buyItem2()
    {
        sumMoney -= 200;
        amountItem2++;
        moneyAmountText.text = sumMoney.ToString();
        amountItem2Text.text = amountItem2.ToString();
    }
}
