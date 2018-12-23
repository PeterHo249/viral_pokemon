using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
    public string itemEffect;

    public Item(string name, string effect)
    {
        this.itemName = name;
        this.itemEffect = effect;
    }
}
