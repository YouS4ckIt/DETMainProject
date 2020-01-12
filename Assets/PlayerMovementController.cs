using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMovementController : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    bool isGrounded;
    Vector3 velocity;
    [SerializeField]
    private PhotonView PV;
    [SerializeField] Camera FPSplayerCam;


    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            FPSplayerCam.enabled = false;
        }
        

    }

    void Update()
    {
        if (!PV.IsMine) { return; }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            Debug.Log("ISGROUNDED ?= " + isGrounded);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;


            controller.Move(move * speed * Time.deltaTime);
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    this.GetComponentInChildren<MouseLook>().SetCursorLock();
            //}
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                Debug.Log("WE JUMPED ONCE! ");
            }


            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
