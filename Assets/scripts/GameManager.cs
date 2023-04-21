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
    bool PassedTheLevelUpCheckpoint = true;
    float startingPos;
    public static float distance;
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
            if(distance > 1 && (int)distance%levelUpAtBlock== 0 && PassedTheLevelUpCheckpoint){
                Instantiate(checkPoint,player.transform.position+player.transform.forward * offset,Quaternion.identity);
                PassedTheLevelUpCheckpoint = false;
                Debug.Log("distance : " +distance);
            }
            PassedTheLevelUpCheckpoint = true;
            yield return new WaitForSeconds(Time.deltaTime*5);
        }
    }
}
