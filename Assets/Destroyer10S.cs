using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer10S : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
