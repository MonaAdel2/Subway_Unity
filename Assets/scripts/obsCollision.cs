using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsCollision : MonoBehaviour
{
  public uiManager ui;

    private void Start()
    {
     // ui = transform.parent.GetComponent<ObsParent>().uiManager;
    }

    private void OnTriggerEnter(Collider other)
    {
      other.GetComponent<playerController>().enabled = false;
      other.GetComponent<Animator>().SetTrigger("die");
      //ui.gameOver();
    }
}
