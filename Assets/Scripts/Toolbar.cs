using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using static Block;

public class Toolbar : MonoBehaviour
{
    public RectTransform highlight;
    public BlockInteraction blockInteraction;
    public Item[] items;
    public UIItemSlot[] slots;
    public FirstPersonController fpsController;
    public GameObject handLink;
    public int slotIndex = 0;
    private GameObject prefab;

    private void Start()
    {
        foreach(UIItemSlot s in slots)
        {
            ItemStack stack = new ItemStack(items[Random.Range(0,3)], 2);
            ItemSlot slot = new ItemSlot(s, stack);
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
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (scroll > 0)
                slotIndex--;
            else
                slotIndex++;

            if (slotIndex > slots.Length - 1)
                slotIndex = 0;
            if (slotIndex < 0)
                slotIndex = slots.Length - 1;

            //blockInteraction.selectedBlockType = slots[slotIndex].itemSlot.stack.item.blockType;
            highlight.position = slots[slotIndex].slotIcon.transform.position;
            Destroy(prefab);
            prefab = Instantiate(slots[slotIndex].itemSlot.stack.item.prefab);
            prefab.transform.parent = handLink.transform;
            prefab.transform.localPosition = Vector3.zero;
        }
    }
}
