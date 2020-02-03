using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WaterDroneTarget : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //allows for the target to only be destroyed if hit by a bullet
        if (collision.collider.CompareTag("FireBullet"))
        {

            NetworkServer.Destroy(gameObject);

        }
    }


}
