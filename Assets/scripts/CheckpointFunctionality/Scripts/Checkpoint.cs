using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Checkpoint : MonoBehaviour
{
    playerController player;
    [SerializeField] int speedIncreaseAmountPerLevel;
   [SerializeField] public UnityEvent onReachingNextLevel;
    static int levelCounter = 0;
    void OnTriggerEnter(Collider other){
        if(other.transform.CompareTag("Player")){
            //MoveToNextLevel
            player = other.GetComponent<playerController>();

            onReachingNextLevel.AddListener(() => player.IncreaseSpeed(speedIncreaseAmountPerLevel));
            onReachingNextLevel.AddListener(()=>player.ActivatePanel());

            onReachingNextLevel.Invoke();
            levelCounter++;
        }

    }
    public static int GetCurrentLevel()
    {
        return levelCounter;
    }
 
}
