using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
   void OnTriggerEnter(Collider other )
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInChildren<Animator>().SetTrigger("Fall");
        }
    }
}
