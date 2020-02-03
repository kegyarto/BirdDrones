﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DroneSpawner : NetworkBehaviour
{

    public GameObject WaterDrone;
    public GameObject FireDrone;
    public GameObject[] myObjects;

    // Start is called before the first frame update
    public override void OnStartServer()
    {
        SpawnDrones();
    }
 

    void SpawnDrones()
    {
        
        for(int i = 0; i < 15; i++)
        {
            if (i % 2 == 0)
            {
                GameObject go = Instantiate(FireDrone,myObjects[i].transform.position,Quaternion.identity);
                NetworkServer.Spawn(go);
            }
            else
            {
                GameObject go = Instantiate(WaterDrone, myObjects[i].transform.position, Quaternion.identity);
                NetworkServer.Spawn(go);
            }
        }
    }
}
