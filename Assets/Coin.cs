using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	private void OnTriggerEnter( Collider other )
	{
		if (other.CompareTag("Player"))
		{
			GetComponent<AudioSource>().PlayOneShot(clip);
		}
	}
}
