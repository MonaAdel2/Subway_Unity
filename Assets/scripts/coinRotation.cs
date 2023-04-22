using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class coinRotation : MonoBehaviour
{
    [SerializeField] float speed = 45f;
    [SerializeField] bool rotateAroundZOnly;

    void Update()
    {
        if (rotateAroundZOnly)
        {
            transform.Rotate(new Vector3(0 , 0 , speed) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(speed , speed , speed) * Time.deltaTime);
        }
    }
}
