using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Toolbar : MonoBehaviour
{
    public RectTransform highlight;
    //public BlockInteraction blockInteraction;
    public Item[] items;
    public UIItemSlot[] slots;
    //public GameObject handLink;
    public int slotIndex = 0;
    //private GameObject prefab;

    private void Start()
    {
        foreach(UIItemSlot s in slots)
        {
            //ItemStack stack = new ItemStack(items[Random.Range(0,3)], 2);
            //ItemSlot slot = new ItemSlot(s, stack);
        }
    }

    //private void Start()
    //{
    //    foreach (ItemSlot slot in itemSlots)
    //    {
    //        int randomNumber = Random.Range(0, items.Length);
    //        slot.blockType = items[randomNumber].blockType;
    //        slot.icon.sprite = items[randomNumber].UIImage;
    //        slot.icon.enabled = true;

    //    }

    //    blockInteraction.selectedBlockType = itemSlots[slotIndex].blockType;
    //}

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotIndex = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotIndex = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            slotIndex = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            slotIndex = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            slotIndex = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            slotIndex = 8;
        }

        //blockInteraction.selectedBlockType = slots[slotIndex].itemSlot.stack.item.blockType;
        highlight.position = slots[slotIndex].slotIcon.transform.position;
            //Destroy(prefab);
            //prefab = Instantiate(slots[slotIndex].itemSlot.stack.item.prefab);
            //prefab.transform.parent = handLink.transform;
            //prefab.transform.localPosition = Vector3.zero;
    }
}
