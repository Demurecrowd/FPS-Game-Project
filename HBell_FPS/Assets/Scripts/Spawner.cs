using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float spawnStartDelay = 5.0f;
    private float nextSpawnTime = 0.0f;

    public float minSpawnRate, maxSpawnRate;

    private void Start()
    {
        nextSpawnTime = spawnStartDelay;
    }

    public GameObject thingToSpawn;

    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Random.RandomRange(minSpawnRate, maxSpawnRate);
            Instantiate(thingToSpawn, transform.position, transform.rotation);
        }
    }
}