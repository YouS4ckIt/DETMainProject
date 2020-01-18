﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragAndDropHandler : MonoBehaviour
{
    [SerializeField]
    private UIItemSlot cursorSlot = null;
    private ItemSlot cursorItemSlot;
    [SerializeField]
    private GraphicRaycaster m_RayCaster = null;
    private PointerEventData m_PointerEventData;
    [SerializeField]
    private EventSystem m_EventSystem = null;

    public PlayerControll playerController;

    private void Start()
    {
        cursorItemSlot = new ItemSlot(cursorSlot);
    }

    private void Update()
    {
        if (!playerController.inUI)
            return;

        cursorSlot.transform.position = Input.mousePosition;
            
        if (Input.GetMouseButtonDown(0))
        {
            HandleSlotClick(CheckForSlot());
        }
    }

    private void HandleSlotClick(UIItemSlot clickedSlot)
    {
        if (clickedSlot == null)
            return;
        if (!cursorSlot.HasItem && !clickedSlot.HasItem)
            return;
        //if (clickedSlot.itemSlot.isCreative)
        //{
        //    cursorItemSlot.EmptySlot();
        //    cursorItemSlot.InsertStack(clickedSlot.itemSlot.stack);
        //}
        if(!cursorSlot.HasItem && clickedSlot.HasItem)
        {
            cursorItemSlot.InsertStack(clickedSlot.itemSlot.TakeAll());
            return;
        }
        if (cursorSlot.HasItem && !clickedSlot.HasItem)
        {
            clickedSlot.itemSlot.InsertStack(cursorItemSlot.TakeAll());
            return;
        }
        if (cursorSlot.HasItem && clickedSlot.HasItem)
        {
            if(cursorSlot.itemSlot.stack.item != clickedSlot.itemSlot.stack.item)
            {
                ItemStack oldCursorSlot = cursorSlot.itemSlot.TakeAll();
                ItemStack oldSlot = clickedSlot.itemSlot.TakeAll();

                clickedSlot.itemSlot.InsertStack(oldCursorSlot);
                cursorSlot.itemSlot.InsertStack(oldSlot);
            }
        }
    }

    private UIItemSlot CheckForSlot()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        m_RayCaster.Raycast(m_PointerEventData, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject.tag == "UIItemSlot")
                return result.gameObject.GetComponent<UIItemSlot>();              
        }

        return null;
    }
}