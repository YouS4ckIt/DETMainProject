using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PhotonLobbby : MonoBehaviourPunCallbacks
{
    public static PhotonLobbby lobby;

    public GameObject startButton;
    public GameObject cancelButton;


    private void Awake()
    {
        lobby = this;
    }


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }


    public override void OnConnectedToMaster()
    {

        Debug.Log("Player connected to Master: ");
        PhotonNetwork.AutomaticallySyncScene = true;
        startButton.SetActive(true);
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("StartButton was clicked");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to Join a Room");
        CreateRoom();

    }

    void CreateRoom()
    {
        Debug.Log("Creating Room");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSettings.multiplayerSettings.maxPlayers };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
      
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create Room...... trying again");
        CreateRoom();
    }

    public void CancelButton()
    {
        cancelButton.SetActive(false);
        startButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }


}
