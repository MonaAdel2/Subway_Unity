using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsController : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject coinPoints;
    private List<GameObject> Points;
   // public bool coinCondition = false;
    void Start()
    {
        Points = new List<GameObject>();
        for (int i=0; i < coinPoints.transform.childCount; i++){
            Points.Add(coinPoints.transform.GetChild(i).gameObject);
        } 
       // if (coinCondition){
            createCoin();
      //  }
        
    }

    void createCoin(){
        int randomNo = Random.Range(0, Points.Count);
        GameObject c = Instantiate(coinPrefab, Points[randomNo].transform.position, Quaternion.identity).gameObject;

        c.transform.forward = new Vector3(0,1,0); 
        

    }

}
