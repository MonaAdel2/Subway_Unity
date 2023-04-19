using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] float speed= 600;

    void Update()
    {
        transform.Rotate(new Vector3(0 , speed , 0) * Time.deltaTime);       
    }
}
