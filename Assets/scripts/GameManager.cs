using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject checkPoint;
    [SerializeField] float offset;
    int counter = 0; 
    public void StartCounting(){
        StartCoroutine(GameCoroutine());
    }
    IEnumerator GameCoroutine(){
        while(true){
            counter +=1;
            Debug.Log("Counter modulus 10: "+ counter%5);
            Debug.Log("playerPosition: "+player.transform.position);
            if(counter%5 == 0){
                Instantiate(checkPoint,player.transform.position+player.transform.forward * offset,Quaternion.identity);
            }
        yield return new WaitForSeconds(1);
        }
    }
  public void GoToLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void GoToNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    
}
