using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerObject : NetworkBehaviour
{
    // Variables
    public GameObject PlayerUnitPrefab;

    [SyncVar]
    public string GuildName = "NoGuild";

    public string PlayerName = "Anonymous";


    void Start()
    {
        if (!isLocalPlayer)
        {
            //This Object is not mine
            return;
        }
        // PlayerObject is Invisible 
        // Make something Physical
        
        CmdSpawnMyUnit();
    }
    GameObject myPlayerUnit;
    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go =  Instantiate(PlayerUnitPrefab);
        myPlayerUnit = go;

        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        NetworkServer.SpawnWithClientAuthority(go,connectionToClient);

    }
    [Command]
    void CmdChangePlayerName(string n)
    {
        PlayerName = n;
        Debug.Log("CmdChangePlayerName Player Name : " + PlayerName );

    }





    void Update()
    {
        if (!isLocalPlayer) { return; }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            string n = "Tester" + Random.Range(1, 100);
            Debug.Log("Sending Request Fore Name Change to : " + n);
            CmdChangePlayerName(n);

            //For All Update new name : 
            //Implementing RPC 
            RpcChangePlayerName(PlayerName);

        }
    }

    // RPC 
    [ClientRpc]
    void RpcChangePlayerName(string n)
    {
        Debug.Log("RPCCHANGePlayerName  : Change THE NAME NOW  BLYAAADJ "+n);
        PlayerName = n;
    }
}
