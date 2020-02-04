using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DroneSpawner : NetworkBehaviour
{

    public GameObject WaterDrone;
    public GameObject FireDrone;
    public GameObject Door;
    public GameObject[] myObjects;
    public GameObject[] doorObjects;
    public List<GameObject> droneArray;
    public List<GameObject> doorArray;


    // Start is called before the first frame update
    public override void OnStartServer()
    {
        droneArray = new List<GameObject>();
        doorArray = new List<GameObject>();
        SpawnDrones();
        SpawnDoors();
 
    }

    void Update()
    {
        int x = 0;
        foreach (GameObject obj in droneArray)
        {
            if (obj == null)
            {
                x++;
            }
        }

        if(x >= 2)
        {
            if (doorArray[0] != null)
            {
                NetworkServer.Destroy(doorArray[0]);
            }
        }
        else if (x >= 6)
        {
            if (doorArray[1] != null)
            {
                NetworkServer.Destroy(doorArray[1]);
            }
        }
        else if (x >= 10)
        {
            if (doorArray[2] != null)
            {
                NetworkServer.Destroy(doorArray[2]);
            }
        }
        else if (x >= 14)
        {
            if (doorArray[3] != null)
            {
                NetworkServer.Destroy(doorArray[3]);
            }
        }
    }


    void SpawnDrones()
    {
        
        for(int i = 0; i < 15; i++)
        {
            if (i % 2 == 0)
            {
                GameObject go = Instantiate(FireDrone,myObjects[i].transform.position,Quaternion.identity);
                NetworkServer.Spawn(go);
                droneArray.Add(go);
            }
            else
            {
                GameObject go = Instantiate(WaterDrone, myObjects[i].transform.position, Quaternion.identity);
                NetworkServer.Spawn(go);
                droneArray.Add(go);
            }
        }
    }

    void SpawnDoors()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(Door, doorObjects[i].transform.position, Quaternion.identity);
            NetworkServer.Spawn(go);
            doorArray.Add(go);
        }
    }

}
