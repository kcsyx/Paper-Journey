using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject dropletPrefab;

    [SerializeField]
    private float dropletInterval = 2.0f;

    void Start()
    {
        StartCoroutine(spawnDroplet(dropletInterval, dropletPrefab));
    }

    IEnumerator spawnDroplet(float interval, GameObject droplet)
    {   
        yield return new WaitForSeconds(interval);
        GameObject newDroplet = Instantiate(droplet, transform.position, Quaternion.identity);
        StartCoroutine(spawnDroplet(interval, droplet));
    }
}
