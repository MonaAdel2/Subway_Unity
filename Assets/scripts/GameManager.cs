using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject checkPoint;
    [SerializeField] float offset;
    [SerializeField] float distanceToChangeLevelAt = 5;
    Vector3 startingPos;
    private void Start()
    {
        startingPos = player.position;    
    }
    public void StartCounting(){
        StartCoroutine(GameCoroutine());
    }
    IEnumerator GameCoroutine(){
        while(true){
            float distance = Vector3.Distance(player.position,startingPos);
            //Debug.Log("Counter modulus 5: "+ counter%5);
            //Debug.Log("playerPosition: "+player.transform.position);
            if(distance%distanceToChangeLevelAt== 0){
                Instantiate(checkPoint,player.transform.position+player.transform.forward * offset,Quaternion.identity);
            }
        yield return new WaitForSeconds(1);
        }
    }
}
