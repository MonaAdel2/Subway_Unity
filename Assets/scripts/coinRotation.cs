using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotation : MonoBehaviour
{
    [SerializeField] float speed = 45f;
    void Update()
    {
        transform.Rotate(new Vector3(speed, speed , speed) * Time.deltaTime);
    }
}
