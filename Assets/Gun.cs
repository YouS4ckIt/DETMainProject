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

		void Start() {
            spawnPosition = transform.Find("BulletSpawn");
			
		}

// TODO: add pooling
public void Shoot()
{
    Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);
}

	}

