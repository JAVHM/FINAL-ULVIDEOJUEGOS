using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }
    
    private void SpawnEnemy()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
