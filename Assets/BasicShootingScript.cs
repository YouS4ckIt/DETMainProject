using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class BasicShootingScript : MonoBehaviour
{


    [SerializeField]
    Transform rightHand;
    [SerializeField]
    private GameObject thirdPCamera;
    [SerializeField]
    GameObject bulletPrefab = null;
    [SerializeField]
    Transform spawnPosition;
    [SerializeField]
    Transform bulletsHolder;
    [SerializeField] private GameObject GunObject;
    [SerializeField] private PhotonPlayer playerSetup;
    [SerializeField] private GameObject ThirdPPosition;
    public GameObject firePoint;
    public List<GameObject> VFXs = new List<GameObject>();
    private int count = 0;
    private float timeToFire = 0f;
    private GameObject effectToSpawn;
    //NON SERIALISED
    PhotonView PV;
    Gun gun;
    public Transform rayOrigin;

    public float maximumLenght;
    private WaitForSeconds updateTime = new WaitForSeconds(0.01f);
    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    private Vector2 mousePos;
    private LineRenderer laserLine;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            return;
        }
        laserLine = GetComponent<LineRenderer>();
        effectToSpawn = VFXs[0];
        playerSetup = GetComponent<PhotonPlayer>();
        gun = rightHand.GetComponentInChildren<Gun>();
       // StartUpdateRay();
    }
    public void StartUpdateRay()
    {
        StartCoroutine(UpdateRay());
    }

    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Normal Shot" + PV.IsMine);
            //PV.RPC("RPC_shooting", RpcTarget.All);
            /// 
            Ray rayOrigin =new Ray(thirdPCamera.GetComponent<Camera>().transform.position, thirdPCamera.GetComponent<Camera>().transform.forward );
            Vector3 origin = thirdPCamera.GetComponent<Camera>().transform.position;
            Vector3 dir = (thirdPCamera.GetComponent<Camera>().transform.forward).normalized;
            //laserLine.SetPosition(0, spawnPosition.position);
            
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin,out hitInfo, 100))
            {
                Debug.DrawLine(spawnPosition.position, hitInfo.point, Color.white);
                Debug.Log("WE SHOT");
                //laserLine.SetPosition(1, hitInfo.point);
                Vector3 mousePositionWorldSpace = thirdPCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                mousePos = thirdPCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - thirdPCamera.GetComponent<Camera>().transform.position.z));
                Debug.Log("what we hit : " + hitInfo.collider.name);


                // Instantiate(bulletPrefab, spawnPosition.position, Quaternion.Euler(new Vector3(mousePositionWorldSpace.x-180f, 0f, mousePositionWorldSpace.z-90f)));
                //PV.RPC("RPC_basicShooting", RpcTarget.All);

                if (hitInfo.transform.tag == "PhotonCharacter")
                {
                    Debug.Log("Did Hit");
                    hitInfo.collider.GetComponent<PlayerControll>().playerHealth -= this.GetComponent<PlayerControll>().playerDamage;
                    Debug.Log("HEALTHY : " + hitInfo.collider.GetComponent<PlayerControll>().playerHealth);
                    
                }
            }
            else
            {
                Debug.DrawLine(ThirdPPosition.transform.position, thirdPCamera.GetComponent<Camera>().WorldToScreenPoint(ThirdPPosition.transform.position));
                laserLine.SetPosition(0, spawnPosition.position);
                Debug.Log(dir + "this is DIR:");
                laserLine.SetPosition(1, (thirdPCamera.GetComponent<Camera>().transform.position- thirdPCamera.GetComponent<Camera>().transform.forward) * -1);
                Debug.Log("WE SHOT");
                Debug.Log("what we hit nothing : ");
                Instantiate(bulletPrefab, spawnPosition.position, Quaternion.Euler(dir-origin));

            }
        }
        if (Input.GetMouseButtonDown(1) && Time.time >= timeToFire)
        {
            Debug.Log("Started Special Ability ");
            timeToFire = Time.time + 1f / effectToSpawn.GetComponent<ProjectileMoveScript>().fireRate;
            SpawnVFX();

        }
    }

    public void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, spawnPosition.position, spawnPosition.rotation);
            //vfx.transform.localRotation = this.rotation;
            vfx.AddComponent<Destroyer10S>();
            if (vfx.transform.childCount > 0)
            {
                var ps = vfx.transform.GetChild(0).GetComponent<ParticleSystem>();
            }
        }

       
    }

    IEnumerator UpdateRay()
    {
        if (thirdPCamera != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = thirdPCamera.GetComponentInChildren<Camera>().ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLenght))
            {
                Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.white);
                RotateToMouse(GunObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maximumLenght);
                RotateToMouse(GunObject, pos);
            }
            yield return updateTime;
            StartCoroutine(UpdateRay());
        }
        else
        {
            Debug.Log("Camera not set");
        }
    }


    void RotateToMouse(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    void DoAttack()
    {
        gun.Shoot();
    }
    [PunRPC]
    void RPC_basicShooting()
    {
       
        Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);
    }
    [PunRPC]
    void RPC_shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.InverseTransformDirection(Vector3.up), out hit, 1000))
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            Debug.Log("Did Hit");
            if (hit.transform.tag == "PhotonCharacter")
            {
                hit.transform.gameObject.GetComponent<PhotonPlayer>().playerHealthBasic -= playerSetup.playerDamageBasic;
            }
        }
        else
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }



    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        DoAttack();
    //    }
    //}

    //void DoAttack()
    //{
    //    gun.Shoot();
    //}

}