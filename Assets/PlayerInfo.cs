﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public static PlayerInfo PI;

    public int selectedCharacter;

    public GameObject[] allCharacters;

    private void OnEnable()
    {
        if(PlayerInfo.PI == null)
        {
            PlayerInfo.PI = this;
        }
        else
        {
            if(PlayerInfo.PI != this)
            {
                Destroy(PlayerInfo.PI.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            selectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            selectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", selectedCharacter);
        }
    }




}
