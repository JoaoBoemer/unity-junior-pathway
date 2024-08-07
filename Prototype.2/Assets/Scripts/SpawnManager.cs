using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Spawns a random animal each 1,5 seconds
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Chooses the animal which will spawn and the position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        
        // Instantiate the animal
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
