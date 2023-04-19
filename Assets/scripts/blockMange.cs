using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMange : MonoBehaviour
{
    //public uiManager uiManager;

    [SerializeField] GameObject lastBlock;
    [SerializeField] List<GameObject>blockPrefab;

    [SerializeField] float offset=30;

    public void createBlock(GameObject block)
    {
        int randomBlock = Random.Range(0 , blockPrefab.Count);
        lastBlock = Instantiate(blockPrefab[randomBlock], new Vector3(0, 0, lastBlock.transform.position.z + offset), Quaternion.identity, transform);
        StartCoroutine(destroyBlock(block));
    }

    IEnumerator destroyBlock(GameObject block)
    {
        yield return new WaitForSeconds(7f);
        Destroy(block);
    }
}
