using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPose : MonoBehaviour

{
    public Transform playerPosition;
    public Vector3 offset; 

    private void Update()
    {
        transform.position = playerPosition.position + offset;
    }
}