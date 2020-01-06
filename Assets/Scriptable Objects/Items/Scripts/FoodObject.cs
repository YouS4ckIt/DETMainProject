using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory System/Items/Food")]
public class FoodObject : Item
{

    public int restoreHealth;
    public int restoreMana;
    //Stamina,Mana and and and added later towards the end of the game  ; 
    public void Awake()
    {
        type = ItemType.Food;
    }    
}
