using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Block;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject{

    public string ItemName;
    public BlockType blockType;
    public bool IsBlock;
    public Sprite UIImage;
    public GameObject prefab;

    public int durability;
    public int dmg;


}
