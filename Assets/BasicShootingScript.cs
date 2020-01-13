using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShootingScript : MonoBehaviour
{

    [SerializeField]
    Transform rightHand;

    Gun gun;

    void Start()
    {
        gun = rightHand.GetComponentInChildren<Gun>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoAttack();
        }
    }

    void DoAttack()
    {
        gun.Shoot();
    }

}