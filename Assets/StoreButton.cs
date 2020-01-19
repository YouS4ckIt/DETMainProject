using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoreButton : MonoBehaviour
{
    public Transform centerStore;
    public Transform storeContainer;
    public void OnClickCharacter()
    {
        float dis = centerStore.position.x - transform.position.x;
        StoreController.newPose = new Vector3(storeContainer.position.x + dis, storeContainer.position.y, storeContainer.position.z);
        StoreController.SelectMove = true;
    }
    public void SelectCharacter(int whichCharacter)
    {
        Debug.Log("SelectedCharacter is : " + whichCharacter);
    }
}