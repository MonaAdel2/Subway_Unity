using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Checkpoint : MonoBehaviour
{
    playerController player;
    [SerializeField] int speedIncreaseAmountPerLevel;
   [SerializeField] public UnityEvent onReachingNextLevel;
    static public int levelCounter = 1;
    public static int ObstacleLevel { get; set; }

    private void AddListeners()
    {
        onReachingNextLevel.AddListener(() => player.IncreaseSpeed(speedIncreaseAmountPerLevel));
        onReachingNextLevel.AddListener(() => player.ActivatePanel());
        onReachingNextLevel.AddListener(() => FindObjectOfType<SoundEffectsManager>().playLevelUpSound());
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.CompareTag("Player")){
            //MoveToNextLevel
            player = other.GetComponent<playerController>();
            AddListeners();
            onReachingNextLevel.Invoke();
            levelCounter++;
            ObstacleLevel++;
        }
    }
    public static int GetCurrentLevel()
    {
        return levelCounter;
    }
}
