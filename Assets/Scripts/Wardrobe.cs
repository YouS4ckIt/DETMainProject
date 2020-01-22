using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public UIItemSlot[] slots;
    public Toolbar toolbar;
    public GameObject headwear;

    private Item[] items;
    private bool headwearEquipped;


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
            if (!headwearEquipped)
            {
                Debug.Log("HEAD");;
                GameObject obj = Instantiate(slots[0].itemSlot.stack.item.prefab) as GameObject;
                //obj.transform.transform.localPosition = headwear.transform.localPosition;
                //obj.transform.transform.localRotation = headwear.transform.localRotation;
                obj.transform.parent = headwear.transform;
                headwearEquipped = true;
            }
        }
        else
        {
            Destroy(headwear.transform.GetChild(0).gameObject);
            headwearEquipped = false;
        }


    }
}
