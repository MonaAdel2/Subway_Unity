using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 distance;
    void Start()
    {
        distance = transform.position - playerTransform.position;
    }
    void LateUpdate()
    {
        transform.position = new Vector3( transform.position.x, 
        playerTransform.position.y + distance.y, 
        playerTransform.position.z + distance.z);
    }
}
