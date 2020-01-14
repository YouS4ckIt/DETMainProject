using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    public bool isLinked = false;
    public ItemSlot itemSlot;
    public Image slotImage;
    public Image slotIcon;
    public Text slotAmount;

    public bool HasItem
    {
        get
        {
            if (itemSlot == null)
                return false;
            else
                return itemSlot.HasItem;
        }
    }

    public void Link(ItemSlot _itemSlot)
    {
        itemSlot = _itemSlot;
        isLinked = true;
        itemSlot.LinkUISlot(this);
        UpdateSlot();
    }

    public void UnLink()
    {
        itemSlot.UnLinkUISlot();
        itemSlot = null;
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        if (itemSlot != null && itemSlot.HasItem)
        {
            slotIcon.sprite = itemSlot.stack.item.UIImage;
            slotAmount.text = itemSlot.stack.amount.ToString();
            slotIcon.enabled = true;
            slotAmount.enabled = true;
        }
        else
            Clear();
    }

    public void Clear()
    {
        slotIcon.sprite = null;
        slotAmount.text = null;
        slotIcon.enabled = false;
        slotAmount.enabled = false;
    }

    private void OnDestroy()
    {
        if (isLinked)
            itemSlot.UnLinkUISlot();
    }
}

public class ItemSlot
{
    public ItemStack stack = null;
    //public bool isCreative;
    private UIItemSlot uiItemSlot = null;

    public bool HasItem
    {
        get
        {
            if (stack != null)
                return true;
            else
                return false;
        }
    }

    public ItemSlot(UIItemSlot _uiItemSlot)
    {
        stack = null;
        uiItemSlot = _uiItemSlot;
        uiItemSlot.Link(this);
    }

    public ItemSlot(UIItemSlot _uiItemSlot, ItemStack _stack)
    {
        stack = _stack;
        uiItemSlot = _uiItemSlot;
        uiItemSlot.Link(this);
    }

    public void LinkUISlot(UIItemSlot uiSlot)
    {
        uiItemSlot = uiSlot;
    }

    public void UnLinkUISlot()
    {
        uiItemSlot = null;
    }

    public void EmptySlot()
    {
        stack = null;
        if (uiItemSlot != null)
            uiItemSlot.UpdateSlot();
    }

    public int Take(int amount)
    {
        if (amount > stack.amount)
        {
            int amt = stack.amount;
            EmptySlot();
            return amt;
        } else if(amount < stack.amount)
        {
            stack.amount -= amount;
            uiItemSlot.UpdateSlot();
            return amount;
        }
        else
        {
            EmptySlot();
            return amount;
        }
            
    }

    public ItemStack TakeAll()
    {
        ItemStack handOver = new ItemStack(stack.item, stack.amount);
        EmptySlot();
        return handOver;
    }

    public void InsertStack(ItemStack _stack)
    {
        stack = _stack;
        uiItemSlot.UpdateSlot();
    }
}
