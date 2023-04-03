using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Checkpoint : MonoBehaviour
{
    playerController player;
    [SerializeField] int speedIncreaseAmountPerLevel;
   [SerializeField] public UnityEvent onReachingNextLevel;
    void OnTriggerEnter(Collider other){
        if(other.transform.CompareTag("Player")){
            //MoveToNextLevel
            player = other.GetComponent<playerController>();
            int speed = player.IncreaseSpeed(speedIncreaseAmountPerLevel);
            onReachingNextLevel.AddListener(() => player.IncreaseSpeed(speedIncreaseAmountPerLevel));

            onReachingNextLevel.AddListener(() => player.ActivatePanel());
        }
    }
 
}
