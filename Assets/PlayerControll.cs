using UnityEngine;
using Photon.Pun;


    public class PlayerControll : MonoBehaviour
    {
        public float movementSpeed = 0.2f;
        public float rotationSpeed = 1f;
        public Transform cameraTransform;

        Animator animator;
        int animSpeedX;
        int animSpeedY;
        int animIsJumping;

        CharacterController controller;

        // Jump
        public float gravity = 30f;
        public float fallCoef = 2f;
        public float jumpForce = 14f;


        bool isGrounded = false;
        bool thirdpersonCameraIsActive = true;
        [SerializeField]
        private PhotonView PV;
        [SerializeField] Camera FPSplayerCam;
        [SerializeField] Camera ThirdpersonplayerCam;
    [SerializeField] GameObject FPSCameraObject;
        Vector3 jumpVelocity = Vector3.zero;
        Vector3 moveInCameraSpace;
        void Start()
        {
            PV = GetComponent<PhotonView>();
            //if (!PV.IsMine)
            //{
            //    FPSplayerCam.enabled = false;
            //    return;
            //}
            animator = GetComponent<Animator>();
            animSpeedX = Animator.StringToHash("SpeedX");
            animSpeedY = Animator.StringToHash("SpeedY");
            animIsJumping = Animator.StringToHash("IsJumping");
            FPSplayerCam.enabled = false;
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {

        //if (!PV.IsMine) { return; }
        if (Input.GetKeyDown(KeyCode.N))
        {

            thirdpersonCameraIsActive = !thirdpersonCameraIsActive;
            Debug.Log("Thirdpersoncamera : " + thirdpersonCameraIsActive);
            FPSplayerCam.enabled = !FPSplayerCam.enabled;
            FPSCameraObject.SetActive(FPSplayerCam.enabled);
            Debug.Log("FPSCAMENABLED : " + FPSplayerCam.enabled);
            ThirdpersonplayerCam.enabled = !ThirdpersonplayerCam.enabled;

        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

            // Movement
            Vector3 movement = new Vector3(
                x ,
                0f,
                y 
            ).normalized;

        // Convert input movement to camera space
        if (thirdpersonCameraIsActive) {
            moveInCameraSpace = cameraTransform.TransformDirection(movement * movementSpeed * Time.deltaTime);
            transform.rotation = cameraTransform.rotation;
        }
        else
        {
            moveInCameraSpace = movementSpeed * transform.right * x * Time.deltaTime + movementSpeed * transform.forward * y * Time.deltaTime;
        }
            // Jump
            if (controller.isGrounded)
            {
                isGrounded = true;
                animator.SetBool(animIsJumping, !isGrounded);

                jumpVelocity.y = -gravity * Time.deltaTime;

                if (Input.GetButtonDown("Jump"))
                {
                    jumpVelocity.y = jumpForce;
                }
            }
            else
            {
            isGrounded = false;
                animator.SetBool(animIsJumping, !isGrounded);

                // If it is falling
                if (jumpVelocity.y < 0)
                {
                    jumpVelocity.y -= gravity * Time.deltaTime * fallCoef;
                }
                else
                {
                    jumpVelocity.y -= gravity * Time.deltaTime;
                }
            }

            controller.Move(jumpVelocity + moveInCameraSpace);

            // Anims
            animator.SetFloat(animSpeedX, x);
            animator.SetFloat(animSpeedY, y);
        }
    }
