using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public UIItemSlot[] slots;
    public Toolbar toolbar;
    public GameObject headwear;
    public GameObject bodywear;
    public GameObject leftFootWear;
    public GameObject rightFootWear;

    private Item[] items;
    private bool headwearEquipped;
    private bool bodywearEquipped;
    private bool footwearEquipped;


    void Start()
    {
        items = toolbar.items;
        foreach (UIItemSlot s in slots)
        {
            ItemStack stack = null;
            ItemSlot slot = new ItemSlot(s, stack);
        }

    }

    private void Update()
    {
        if(slots[0] != null && slots[0].itemSlot.stack != null)
        {
            if (!headwearEquipped && slots[0].itemSlot.stack.item.itemType == ItemTypes.HeadGear)
            {
                GameObject obj = Instantiate(slots[0].itemSlot.stack.item.prefab, headwear.transform) as GameObject;
                headwearEquipped = true;
            }
        }
        else
        {
            if (headwearEquipped)
            {
                Destroy(headwear.transform.GetChild(0).gameObject);
                headwearEquipped = false;
            }
        }

        if (slots[1] != null && slots[1].itemSlot.stack != null)
        {
            if (!bodywearEquipped && slots[1].itemSlot.stack.item.itemType == ItemTypes.BodyGear)
            {
                GameObject obj = Instantiate(slots[1].itemSlot.stack.item.prefab, bodywear.transform) as GameObject;
                bodywearEquipped = true;
            }
        }
        else
        {
            if (bodywearEquipped)
            {
                Debug.Log("HHH" + bodywear.transform.childCount);
                Destroy(bodywear.transform.GetChild(0).gameObject);
                bodywearEquipped = false;
            }  
        }

        if (slots[2] != null && slots[2].itemSlot.stack != null)
        {
            if (!footwearEquipped && slots[2].itemSlot.stack.item.itemType == ItemTypes.LegGear)
            {
                GameObject obj = Instantiate(slots[2].itemSlot.stack.item.prefab, leftFootWear.transform) as GameObject;
                GameObject obj2 = Instantiate(slots[2].itemSlot.stack.item.prefabAditional, rightFootWear.transform) as GameObject;
                footwearEquipped = true;
            }
        }
        else
        {
            if (footwearEquipped)
            {
                Destroy(leftFootWear.transform.GetChild(0).gameObject);
                Destroy(rightFootWear.transform.GetChild(0).gameObject);
                footwearEquipped = false;
            }
        }
    }
}
