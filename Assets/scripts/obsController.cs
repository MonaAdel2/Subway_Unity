using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsController : MonoBehaviour
{
    [SerializeField] List<ObstacleData> obstacleList;
    [SerializeField] GameObject obsPoints;
    [SerializeField] private List<GameObject> parentPoints;
    [Header("Enemy1")]
    [SerializeField] float enemy1Speed=1;
    [Header("Saw")]
    [SerializeField] float sawSpeed=1;
    [Header("Choco")]
    [SerializeField] Vector3 chocoOffset= new Vector3(1,1,0);
    [Header("Static")]
    [SerializeField] float staticObjectOffset=1;


    int counter;
    int randomNumber1;
    int parentListCounter;
    void Start()
    {
        //********
        counter = Checkpoint.ObstacleLevel;
        if (counter >= obstacleList.Count)
        {
            Checkpoint.ObstacleLevel = 0;
        }
        
        for(int i=0; i<parentPoints.Count; i++){
            randomNumber1 = Random.Range(0 , obsPoints.transform.GetChild(i).childCount);
            parentListCounter = i;
            createObs();
        }
    }
    void createObs(){
        counter = Mathf.Clamp(counter , 0 , obstacleList.Count-1);
        //********
        int randomNumber2 = Random.Range(0,obstacleList[counter].ObstaclesPrefab.Length);
        GameObject spawnedPrefab = obstacleList[counter].ObstaclesPrefab[randomNumber2];
        GameObject obs = Instantiate(spawnedPrefab, parentPoints[parentListCounter].transform.GetChild(randomNumber1).transform.position, spawnedPrefab.transform.rotation);
        List<Transform> childrenOfParentPoints = new List<Transform>();

        for (int i = 0; i < parentPoints[parentListCounter].transform.childCount; i++)
        {
            childrenOfParentPoints.Add(parentPoints[parentListCounter].transform.GetChild(i));
        }

        if (obs.CompareTag("Choco"))
        {
            Transform pointLeft = parentPoints[parentListCounter].transform.GetChild(2);
            obs.transform.position = pointLeft.transform.position - pointLeft.transform.right*chocoOffset.x - pointLeft.transform.up*chocoOffset.y;
        }

        if (obs.CompareTag("Static"))
        {
            Transform middlePoint = parentPoints[parentListCounter].transform.GetChild(1);
            obs.transform.position = middlePoint.transform.position - middlePoint.transform.up * staticObjectOffset;
        }

        if (obs.CompareTag("Enemy1"))
        {
            StartCoroutine(EnemyCoroutine(obs.transform , childrenOfParentPoints, enemy1Speed));
        }

        if (obs.CompareTag("Saw"))
        {
            StartCoroutine(EnemyCoroutine(obs.transform , childrenOfParentPoints , sawSpeed));
        }

        //Debug.Log("Obstacle: " + obs.name);
        //Instantiate(obsPrefab, points[randomNumber1].transform.position, Quaternion.identity);
        //.GetComponent<obsCollision>().ui = transform.parent.GetComponent<blockMange>().uiManager;
    }
    private IEnumerator EnemyCoroutine( Transform enemy , List<Transform> points , float speed )
    {
        Vector3 direction;
        Transform enemyTransform = Enemy1Functionality(enemy , points , speed,out direction);
        while (true)
        {
            if (Vector3.Distance(enemyTransform.position,points[2].position)<0.5f || Vector3.Distance(enemyTransform.position , points[0].position) < 0.5f)
            {
                direction *= -1;
            }
            enemyTransform.Translate(direction * speed * Time.deltaTime);
            yield return null;
        }
    }

    Transform Enemy1Functionality(Transform enemy, List<Transform> points,float speed,out Vector3 directionf)
    {
        directionf = Vector3.zero;
        if (enemy.position ==  points[0].position)
        {
            directionf = enemy.right;
        }
        else if(enemy.position == points[1].position)
        {
            int randomMultiplier = Random.Range(0 , 2);
            if (randomMultiplier == 0)
            {
                directionf = enemy.right;
            }
            else
            {
                directionf = -enemy.right;
            }
        }
        else if (enemy.position == points[2].position)
        {
            directionf = -enemy.right;
        }
        Debug.Log(" value: " + directionf);

        return enemy;
    }
}
[System.Serializable]
public class ObstacleData
{
    public string name;
    public GameObject[] ObstaclesPrefab;
}
