using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour
{
    Rigidbody rb;
    public float speed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        if (!hasAuthority) { return; }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = -transform.right * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -1) * speed;
        }


    }
}
