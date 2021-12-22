using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minmap : MonoBehaviour
{

    public Transform player;
    
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        //newPosition.y = transform.position.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
