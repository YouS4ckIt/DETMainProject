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
    public int playerHealth = 100;
    public int playerDamage = 25;
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
        [SerializeField] GameObject ThirdpersonplayerCamObject;
        [SerializeField] GameObject FPSCameraObject;
    [SerializeField] GameObject UICamera;
        Vector3 jumpVelocity = Vector3.zero;
        Vector3 moveInCameraSpace;

    public GameObject creativeInventoryWindow;
    public GameObject wardrobeWindow;
    public GameObject cursorSlot;
    public GameObject prefab;
    public GameObject uiRawImage;
    private bool _inUI = false;
    public bool inUI
    {
        get { return _inUI; }
        set
        {
            _inUI = value;
            if (_inUI)
            {
                Cursor.lockState = CursorLockMode.None;
                creativeInventoryWindow.SetActive(true);
                wardrobeWindow.SetActive(true);
                cursorSlot.SetActive(true);
                Cursor.visible = (true);
                uiRawImage.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                creativeInventoryWindow.SetActive(false);
                wardrobeWindow.SetActive(false);
                cursorSlot.SetActive(false);
                Cursor.visible = (false);
                uiRawImage.SetActive(false);
            }
        }
    }




    void Start()
        {
            PV = GetComponentInParent<PhotonView>();
            if (!PV.IsMine)
            {
                ThirdpersonplayerCamObject.SetActive(false);
                FPSCameraObject.SetActive(false);
                FPSplayerCam.enabled = false;
                ThirdpersonplayerCam.enabled = false;
                UICamera.SetActive(false);
                return;
            }
            animator = GetComponent<Animator>();
            animSpeedX = Animator.StringToHash("SpeedX");
            animSpeedY = Animator.StringToHash("SpeedY");
            animIsJumping = Animator.StringToHash("IsJumping");
            FPSplayerCam.enabled = false;
            controller = GetComponent<CharacterController>();
        }

    void Update()
    {

        if (!PV.IsMine) { return; }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inUI = !inUI;
        }


        if (!inUI)
        {
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
                x,
                0f,
                y
            ).normalized;

            // Convert input movement to camera space
            if (thirdpersonCameraIsActive)
            {
                moveInCameraSpace = cameraTransform.TransformDirection(movement * movementSpeed * Time.deltaTime);
               // Debug.Log(cameraTransform.rotation + "      ROTATION : "); 
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
                calcVelocity();
            }

            controller.Move(jumpVelocity + moveInCameraSpace);

            // Anims
            animator.SetFloat(animSpeedX, x);
            animator.SetFloat(animSpeedY, y);
        }
        else
        {
            if (!controller.isGrounded)
            {
                isGrounded = false;
                calcVelocity();
            }
            moveInCameraSpace = new Vector3(0f, 0f, 0f);
            animator.SetBool(animIsJumping, false);
            animator.SetFloat(animSpeedX, 0f);
            animator.SetFloat(animSpeedY, 0f);
            controller.Move(jumpVelocity + moveInCameraSpace);
        }
}
    void calcVelocity()
    {
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
    
}
