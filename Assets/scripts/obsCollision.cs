using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsCollision : MonoBehaviour
{
  public uiManager ui;
    bool isDead=true;
    public enum DieAnimation
    {
        die1,
        die2
    }
    public DieAnimation dieAnimation;
    private void Start()
    {
     // ui = transform.parent.GetComponent<ObsParent>().uiManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead)
        {
            other.GetComponent<playerController>().enabled = false;
            if (dieAnimation == DieAnimation.die1)
            {
                other.GetComponent<Animator>().SetTrigger("Die1");
            }
            else if (dieAnimation == DieAnimation.die2)
            {
                other.GetComponent<Animator>().SetTrigger("Die2");
            }

            other.transform.Translate(other.transform.up * 1f);
            isDead = false;
        }
      //ui.gameOver();
    }
}
