using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public bool cooldown = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
       if(cooldown == false)
        {
            cooldown = true;
            
            if(ScoreManager.instance.getscore() <= 9)
            {
                
                StartCoroutine(Cooldown());
                
                int randSpawnPoint2 = Random.Range(-60, -30);
                int randSpawnPoint3 = Random.Range(-60, -30);
                int randomMonster = Random.Range(0, 2);
                Instantiate(enemyPrefabs[randomMonster], new Vector3(randSpawnPoint2, 7, 0), Quaternion.identity);
                ScoreManager.instance.addEnemy();
               // Instantiate(enemyPrefabs[1], new Vector3(randSpawnPoint3, 10, 0), Quaternion.identity);
               
                Debug.Log("Enemys spawned");
                
            }
            
        }
    }

    IEnumerator WaitTime()
    {
        int randSpawnPoint2 = Random.Range(-60, -30);
        int randSpawnPoint3 = Random.Range(-60, -30);
       // int randomMonster = 
        yield return new WaitForSeconds(10);
        Instantiate(enemyPrefabs[0], new Vector3(randSpawnPoint2, 7, 0), Quaternion.identity);
        ScoreManager.instance.addEnemy();
        Instantiate(enemyPrefabs[1], new Vector3(randSpawnPoint3, 10, 0), Quaternion.identity);
        ScoreManager.instance.addEnemy();
        Debug.Log("Enemys spawned");
    }

   IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(10);
        TimeController.instance.BeginTimer();
        cooldown = false;
       // Debug.Log(Random.Range(0, 2));
       // Debug.Log(ScoreManager.instance.getscore()); 
            
    }
}
