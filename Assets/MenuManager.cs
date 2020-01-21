using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject LobbyController;
    [SerializeField] public GameObject startButtonForShow;
    [SerializeField] public GameObject characterSelectObj;
    public void btnPlayGame()
    {
        
        characterSelectObj.SetActive(true);
    }
    public void btnQuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
          Application.Quit();
    #endif
    }

    public void OnClickCharacterPick(int whichCharacter)
    {
        if (PlayerInfo.PI != null)
        {
            PlayerInfo.PI.selectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);
        }
    }







}
