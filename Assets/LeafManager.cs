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
        Instantiate(leafPrefab, new Vector2(179.46f, 56.55f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(185.06f, 59.84f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(179.4601f, 63.54179f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(186.3101f, 66.64178f), leafPrefab.transform.rotation);
        Instantiate(leafPrefab, new Vector2(193.9701f, 63.88179f), leafPrefab.transform.rotation);
    }


    IEnumerator SpawnLeaf(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(leafPrefab, spawnPosition, leafPrefab.transform.rotation);
    }
}
