using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
                if (Random.Range(0.0f, 1.0f) < 0.5)
                {
                    int randIdx = Mathf.RoundToInt(Random.Range(0.0f, enemyPrefabs.Length));
                    GameObject toSpawnObj = enemyPrefabs[randIdx];

                    Instantiate(toSpawnObj, gameObject.transform, true);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
