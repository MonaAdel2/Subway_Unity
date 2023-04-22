using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject checkPoint;
    [SerializeField] float offset;
    [SerializeField] int levelUpAtBlock = 5;
    float startingPos;
    public static float distance;
    [SerializeField] float LevelUpThreshold = .3f;
    private void Start()
    {
        startingPos = player.position.z;
        Checkpoint.ObstacleLevel = 0;
        Checkpoint.levelCounter = 1;
    }
    public void StartCounting(){
        StartCoroutine(GameCoroutine());
    }
    IEnumerator GameCoroutine(){
        while(true){
            distance = player.position.z - startingPos;
            float mod = distance % levelUpAtBlock;
            bool passedTheLevelUpThreshold = mod > 0 && mod <= LevelUpThreshold;
            if (distance > 1 && passedTheLevelUpThreshold ){
                Instantiate(checkPoint,player.transform.position+player.transform.forward * offset,Quaternion.identity);
            }
            yield return null;
        }
    }
}
