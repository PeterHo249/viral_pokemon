using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string name;
    public int amount;

    public Item(int id, string name, int amount)
    {
        this.id = id;
        this.name = name;
        this.amount = amount;
    }
}
