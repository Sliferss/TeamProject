using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject rocket;
    public float speed = 500f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject instRocket = Instantiate(rocket, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instRocketRigidbody = instRocket.GetComponent<Rigidbody>();
            instRocketRigidbody.AddForce(Vector3.forward * speed);
        }
    }
}
