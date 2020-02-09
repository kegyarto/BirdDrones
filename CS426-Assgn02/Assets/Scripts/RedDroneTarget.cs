using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RedDroneTarget : NetworkBehaviour
{
    //public Score scoreManager;
    public float force = 5f;
    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }



    void Update()
    {
        if (!isServer)
        {
            return;
        }

        rb.AddForce(t.up * force);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //allows for the target to only be destroyed if hit by a bullet
        if (collision.collider.CompareTag("WaterBullet"))
        {
            //scoreManager.AddPoint();
            NetworkServer.Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Floor"))
        {
            force = Mathf.Abs(force);
        }

        if (collision.collider.CompareTag("Ceiling"))
        {
            force = Mathf.Abs(force) * -1f;
        }
    }
}
