using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter( Collider other )
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<SoundEffectsManager>().playCoinSound();
            GetComponentInChildren<Renderer>().enabled = false;
            Destroy(gameObject , 1);
        }
    }
}
