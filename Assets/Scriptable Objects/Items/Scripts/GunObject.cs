using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Gun Object", menuName = "Inventory System/Items/Guns")]
public class GunObject : Item
{
    public int ammo;
    public int dmg;
    public bool WorldEdit;
    public bool automatic;
    
    //maybe more types for dmg bazooka and and;
    public void Awake()
    {
        automatic = false;
        ammo = 10;
        dmg = 1;
        WorldEdit = false;
        type = ItemType.Gun;
    }
}
