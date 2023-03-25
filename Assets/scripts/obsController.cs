using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsController : MonoBehaviour
{
    //[SerializeField] List<GameObject> obsPrefab;
    //[SerializeField] GameObject obsPrefab;
    [SerializeField] GameObject[] obsPrefab;
    [SerializeField] GameObject obsPoints;
    private List<GameObject> points;
    void Start()
    {
        //********
        points = new List<GameObject>();
       // obsPrefab = new List<GameObject>();

        for(int i=0; i< obsPoints.transform.childCount; i++){ 
            points.Add(obsPoints.transform.GetChild(i).gameObject);
           
        }
        createObs();
    }
    void createObs(){
        int randomNumber1 = Random.Range(0, points.Count); 
        //********
        int randomNumber2 = Random.Range(0,3);
        Instantiate(obsPrefab[randomNumber2], points[randomNumber1].transform.position, Quaternion.identity);
        //Instantiate(obsPrefab, points[randomNumber1].transform.position, Quaternion.identity);
        //.GetComponent<obsCollision>().ui = transform.parent.GetComponent<blockMange>().uiManager;
    }
}
