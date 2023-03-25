using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMange : MonoBehaviour
{
    //public uiManager uiManager;

    [SerializeField] GameObject lastBlock, blockPrefab;

    public void createBlock(GameObject block)
    {
        lastBlock = Instantiate(blockPrefab, new Vector3(0, 0, lastBlock.transform.position.z + 30), Quaternion.identity, transform);
        StartCoroutine(destroyBlock(block));
    }

    IEnumerator destroyBlock(GameObject block)
    {
        yield return new WaitForSeconds(7f);
        Destroy(block);
    }
}
