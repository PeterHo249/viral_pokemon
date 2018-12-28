using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedItem
{
    public Item sampleItem;
    public int amount;

    public OwnedItem(Item item, int amt)
    {
        this.sampleItem = item;
        this.amount = amt;
    }
}
