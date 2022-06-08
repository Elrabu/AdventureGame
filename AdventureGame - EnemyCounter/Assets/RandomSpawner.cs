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
        int randSpawnPoint2 = Random.Range(-60, -30);
        int randSpawnPoint3 = Random.Range(-60, -30);
        //  Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

        Instantiate(enemyPrefabs[0], new Vector3(randSpawnPoint, 7, 0), Quaternion.identity);
        ScoreManager.instance.addEnemy();
        Instantiate(enemyPrefabs[1], new Vector3(randSpawnPoint, 10, 0), Quaternion.identity);
        ScoreManager.instance.addEnemy();
        // Instantiate(enemyPrefabs[0], new Vector3(randSpawnPoint2, 7, 0), Quaternion.identity);
        // Instantiate(enemyPrefabs[1], new Vector3(randSpawnPoint3, 10, 0), Quaternion.identity);
        StartCoroutine(WaitTime());

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator WaitTime()
    {
        int randSpawnPoint2 = Random.Range(-60, -30);
        int randSpawnPoint3 = Random.Range(-60, -30);
        yield return new WaitForSeconds(10);
        Instantiate(enemyPrefabs[0], new Vector3(randSpawnPoint2, 7, 0), Quaternion.identity);
        ScoreManager.instance.addEnemy();
        Instantiate(enemyPrefabs[1], new Vector3(randSpawnPoint3, 10, 0), Quaternion.identity);
        ScoreManager.instance.addEnemy();
        Debug.Log("Enemys spawned");
    }
}
