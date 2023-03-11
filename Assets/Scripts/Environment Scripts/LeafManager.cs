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
        Instantiate(leafPrefab, new Vector2(198.1f, 55.39f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(194.54f, 59.22f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(197.52f, 66.19f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(200.59f, 69.82f), leafPrefab.transform.rotation);
    }


    IEnumerator SpawnLeaf(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(leafPrefab, spawnPosition, leafPrefab.transform.rotation);
    }
}
