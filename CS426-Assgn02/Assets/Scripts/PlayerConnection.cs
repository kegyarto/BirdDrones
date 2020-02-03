using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnection : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        CmdSpawnMyBird();
    }

    public GameObject PlayerUnitPrefab1;
    public GameObject PlayerUnitPrefab2;

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }

    [Command]
    void CmdSpawnMyBird()
    {
        //give the player a fire or water bird depending on player count
        if (NetworkServer.connections.Count % 2 == 0)
        {
            GameObject go = Instantiate(PlayerUnitPrefab1);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
        else
        {
            GameObject go = Instantiate(PlayerUnitPrefab2);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
        
    }
}
