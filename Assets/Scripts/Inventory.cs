using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{ 
public class Inventory : MonoBehaviour
{
  
  
  public bool inventoryEnabled;
  public GameObject inventory;
  
  private int allSlots;
  private int enabledSlots;
  private GameObject[] slot;
  public GameObject slotHolder;

  public bool getInventoryEnabled()
    {
        return inventoryEnabled;
    }
  
  void Start(){
	allSlots = 35;
	slot = new GameObject[allSlots];
	for(int i = 0;i< allSlots;i++){
		slot[i] = slotHolder.transform.GetChild(i).gameObject;
	}
  }
  
  
  
  void Update(){
	if(Input.GetKeyDown(KeyCode.I)){
		inventoryEnabled = !inventoryEnabled;
	}
	
	if(inventoryEnabled){
            inventory.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else{
            inventory.SetActive(false);
	}
  }
  
}
}