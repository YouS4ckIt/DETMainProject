using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : Item
{
    public float atkBonus;
    public float armorBonus;
    //agility and and and ... 
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
