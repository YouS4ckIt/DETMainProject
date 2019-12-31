﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestConnect : MonoBehaviourPunCallbacks
{

    void Start()
    {
        print("connecting to server");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();


    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To server");
        print("Connecteded to server");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected Because: " + cause.ToString());
    }


}
