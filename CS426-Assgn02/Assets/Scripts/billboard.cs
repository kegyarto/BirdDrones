using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    public Transform cameraTrans;

    Quaternion startingRotation;

    void Start()
    {
        startingRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = cameraTrans.rotation * startingRotation;
    }
}
