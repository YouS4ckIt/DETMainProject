using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{ 
        [SerializeField]
        GameObject bulletPrefab = null;
        Transform spawnPosition;
        [SerializeField]
        Transform bulletsHolder;
        private Vector3 InitialPos;
    public float ammount;
    public float maxAmmount;
    public float smoothAmount;
    void Start() {
            spawnPosition = transform.Find("BulletSpawn");
        InitialPos = transform.localPosition;
		}

    public void Shoot()
    {
        //Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);
    }
    private void Update()
    {
        float movementX = Input.GetAxis("Mouse X");
        float movementY = Input.GetAxis("Mouse Y");
        movementX = Mathf.Clamp(movementX, -maxAmmount, maxAmmount);
        movementY = Mathf.Clamp(movementX, -maxAmmount, maxAmmount);
        Vector3 finalposition = new Vector3(movementX, movementY, 0);
        // transform.localPosition = Vector3.Lerp(transform.localPosition, finalposition + InitialPos, Time.deltaTime* smoothAmount);
    }

 
}

