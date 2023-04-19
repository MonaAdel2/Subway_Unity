using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] [Range(0 , 1)] float volume=1;  
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter( Collider other )
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip,volume);
        }
    }
}
