using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject LobbyController;
    [SerializeField] public GameObject startButtonForShow;
    public void btnPlayGame()
    {
        LobbyController.GetComponent<PhotonLobbby>().StartMultiplayer();
        startButtonForShow.SetActive(true);
    }
    public void btnQuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
          Application.Quit();
    #endif
    }






}
