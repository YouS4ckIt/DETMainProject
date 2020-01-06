﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Block Object", menuName = "Inventory System/Items/Block")]
public class BlockObject : Item
{
    public void Awake()
    {
        type = ItemType.Block;
    }


}
