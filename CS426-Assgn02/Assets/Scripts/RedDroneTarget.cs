using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RedDroneTarget : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //allows for the target to only be destroyed if hit by a bullet
        if (collision.collider.CompareTag("WaterBullet"))
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
