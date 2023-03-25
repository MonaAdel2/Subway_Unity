using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       transform.parent.parent.GetComponent<blockMange>().createBlock(transform.parent.gameObject);
    }
}
