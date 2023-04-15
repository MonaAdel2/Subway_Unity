using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    [SerializeField] uiManager ui;
    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "coins"){
            ui.coinsUpdate();
            // new scripts
            c.GetComponent<AudioSource>().Play();
            
            Destroy(c.gameObject);
        } 
    }
}
