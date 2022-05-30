using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(-60, -30);

        //  Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

        Instantiate(enemyPrefabs[0], new Vector3(randSpawnPoint, 7, 0), Quaternion.identity);
        Instantiate(enemyPrefabs[1], new Vector3(randSpawnPoint, 10, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
