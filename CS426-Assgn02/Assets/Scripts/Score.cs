using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Score : NetworkBehaviour
{
    // Start is called before the first frame update

    public int score = 0;
    public override void OnStartServer()
    {
        score = 0;
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score++;
    }
}
