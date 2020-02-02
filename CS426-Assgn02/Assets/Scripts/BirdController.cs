using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    //https://www.youtube.com/watch?v=n29T85RuWbc

    public float speed;

    public Camera cam;
    public float rotationSpeed;
    public float rotX;
    public float rotY;
    public GameObject cannon;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rotationSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //move player left right up down
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(0f, 0f, 0f);
        }

        //rotate camera based on mouse input
        rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;

        if (rotX < -10)
        {
            rotX = -10;
        }
        else if (rotX > 15)
        {
            rotX = 15;
        }

        //rotate player position based on camera postition
        transform.rotation = Quaternion.Euler(0, rotY, 0);
        cam.transform.rotation = Quaternion.Euler(rotX, rotY, 0);

        transform.forward = cam.transform.forward;

        //shooting bullet
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 1;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
        }
    }
}
