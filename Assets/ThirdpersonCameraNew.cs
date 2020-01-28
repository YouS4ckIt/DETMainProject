using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdpersonCameraNew : MonoBehaviour
{

    [SerializeField] float XSensitivity = 100f;
    public float minimumY = -30f;
    public float maximumY = 30f;
    float rotationY = 0f;
    float mouseX, mouseY;
    [SerializeField] public Transform Target, Player;
    Vector3 offset;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        offset = transform.position - Target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            HandleRotationMovement();
        }
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = Target.transform.position + offset;
        transform.position = desiredPosition;
    }
    public void HandleRotationMovement()
    {
         mouseX += Input.GetAxis("Mouse X") * XSensitivity * Time.deltaTime; 
        mouseY -= Input.GetAxis("Mouse Y") * XSensitivity * Time.deltaTime; 


        mouseY = Mathf.Clamp(mouseY, -35, 60);
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
