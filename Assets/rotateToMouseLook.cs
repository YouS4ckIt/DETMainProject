using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToMouseLook : MonoBehaviour
{
    [SerializeField] GameObject TPSCam;
    private Vector2 mousePos;
    private Vector3 screenPos;
    void Update()
    {

        //mousePos = TPSCam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - TPSCam.GetComponent<Camera>().transform.position.z));
        //this.transform.eulerAngles = new Vector3(Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg - 90, 0, 0);



        ////Get the Screen positions of the object
        //Vector2 positionOnScreen = TPSCam.GetComponent<Camera>().WorldToViewportPoint(transform.position);
        //Debug.Log("OBJECT POOS : " + positionOnScreen);
        ////Get the Screen position of the mouse
        //Vector2 mouseOnScreen = (Vector2)TPSCam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log("MOUSEPOS : " + mouseOnScreen);
        ////Get the angle between the points
        //float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        ////Ta Daaa
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x) * Mathf.Rad2Deg;
    }
}
