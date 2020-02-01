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
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

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

    }
}
