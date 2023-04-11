using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsController : MonoBehaviour
{
    [SerializeField] List<ObstacleData> obstacleList;
    
    [SerializeField] GameObject[] obsPrefab;
    [SerializeField] GameObject obsPoints;
    private List<GameObject> points;
    int counter;
    bool getCurrentLevel=true;
    void Start()
    {
        //********
        points = new List<GameObject>();

        for(int i=0; i< obsPoints.transform.childCount; i++){ 
            points.Add(obsPoints.transform.GetChild(i).gameObject);
        }

        counter = Checkpoint.ObstacleLevel;
        if (counter >= obstacleList.Count)
        {
            Checkpoint.ObstacleLevel = 0;
        }
        createObs();
    }
    void createObs(){
        counter = Mathf.Clamp(counter , 0 , obstacleList.Count-1);
        int randomNumber1 = Random.Range(0, points.Count); 
        //********
        int randomNumber2 = Random.Range(0,obstacleList[counter].ObstaclesPrefab.Length);
        GameObject obs = Instantiate(obstacleList[counter].ObstaclesPrefab[randomNumber2], points[randomNumber1].transform.position, Quaternion.identity);
        //Debug.Log("Obstacle: " + obs.name);
        //Instantiate(obsPrefab, points[randomNumber1].transform.position, Quaternion.identity);
        //.GetComponent<obsCollision>().ui = transform.parent.GetComponent<blockMange>().uiManager;
    }
}
[System.Serializable]
public class ObstacleData
{
    public string name;
    public GameObject[] ObstaclesPrefab;
}
