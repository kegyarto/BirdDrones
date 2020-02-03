using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BirdController : NetworkBehaviour
{

    public float speed;

    //public Camera cam;
    public float rotationSpeed;
    public float rotX;
    public float rotY;
    public GameObject cannon;
    public GameObject bullet;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rotationSpeed = 100f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }

        Camera.main.transform.position = this.transform.position - this.transform.forward * 10 + this.transform.up * 3;
        Camera.main.transform.LookAt(this.transform.position);
        Camera.main.transform.parent = this.transform;

        //move player left right up down
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
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
        Camera.main.transform.rotation = Quaternion.Euler(rotX, rotY, 0);

        transform.forward = Camera.main.transform.forward;

        //shooting bullet
        if (Input.GetButtonDown("Fire1"))
        {
            CmdSpawnMyBullet();
        }
    }

    [Command]
    void CmdSpawnMyBullet()
    {
        GameObject newBullet = Instantiate(bullet, cannon.transform.position, cannon.transform.rotation);
        NetworkServer.Spawn(newBullet);
        newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 1;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
    }
}
