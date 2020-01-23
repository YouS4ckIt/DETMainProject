using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStack
{
    public Item item;
    public int amount;

    public ItemStack(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public ItemStack(Item _item)
    {
        item = _item;
    }
}
