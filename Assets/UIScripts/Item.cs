using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Block;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject{

    public string ItemName;
    public ItemTypes itemType = ItemTypes.Block;
    public Sprite UIImage;
    public GameObject prefab;
    public GameObject prefabAditional;
    public BlockType blockType;

    public int durability;
    public int dmg;


}

public enum ItemTypes { Block, Weapon, HeadGear, BodyGear, LegGear, Any}
