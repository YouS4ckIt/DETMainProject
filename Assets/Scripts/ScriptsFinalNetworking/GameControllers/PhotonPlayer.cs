using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{

    private PhotonView PV;
    public GameObject myAvatar;
    public int playerHealthBasic;
    public int playerDamageBasic;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthBasic = 100;
        playerDamageBasic = 25;
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        Debug.Log("OUR SELECTED CHARACTER IS : " + PlayerInfo.PI.selectedCharacter);
        if (PV.IsMine)
        {
            switch (PlayerInfo.PI.selectedCharacter)
            {
                case 0:
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterBlue"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
                    break;
                case 1:
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterRed"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
                    break;
                case 2:
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterGreen"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
                    break;
                default:
                    break;
            }
            //myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterGreen"),GameSetup.GS.spawnPoints[spawnPicker].position,GameSetup.GS.spawnPoints[spawnPicker].rotation,0);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
