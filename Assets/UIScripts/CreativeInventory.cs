using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeInventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public Toolbar toolbar;

    List<ItemSlot> slots = new List<ItemSlot>();
    private void Start()
    {
        for(int i = 1; i < 55; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, transform);
            //ItemStack stack = new ItemStack(toolbar.items[0], 64);
            ItemSlot slot = new ItemSlot(newSlot.GetComponent<UIItemSlot>());
            //slot.isCreative = true;
        }
    }
}
