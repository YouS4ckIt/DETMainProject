using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{

    private PhotonView PV;
    public GameObject myAvatar;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        Debug.Log("OUR SELECTED CHARACTER IS : " + PlayerInfo.PI.selectedCharacter);
        if (PV.IsMine)
        {
            switch (PlayerInfo.PI.selectedCharacter)
            {
                case 0:
                    PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterBlue"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
                    break;
                case 1:
                    PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterRed"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
                    break;
                case 2:
                    PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerCharacterGreen"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
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
