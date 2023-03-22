using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{
    public static LeafManager LeafManagerInstance = null;

    [SerializeField]
    GameObject leafPrefab;

    private void Awake()
    {
        if (LeafManagerInstance == null)
        {
            LeafManagerInstance = this;
        } else if (LeafManagerInstance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //group 2
        Instantiate(leafPrefab, new Vector2(268.3f, 60.34f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(272.7f, 62.72f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(278.3f, 62.72f), leafPrefab.transform.rotation);
    }


    IEnumerator SpawnLeaf(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(leafPrefab, spawnPosition, leafPrefab.transform.rotation);
    }
}
