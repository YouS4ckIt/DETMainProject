using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  
  
  public bool inventoryEnabled;
  public GameObject Inventory;
  
  private int allSlots;
  private int enabledSlots;
  private GameObject[] slot;
  public GameObject slotHolder;
  
  
  void Start(){
	allSlots = 26;
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
		Inventory.SetActive(true);
	}else{
		Inventory.SetActive(false);
	}
  }
  
}
