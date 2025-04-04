using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyprefab;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] float spawnDistance = 10f;
    Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-21.6f, 42), 8f + spawnDistance);
                Debug.Log(side);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-21.6f, 42), -7f - spawnDistance);
                Debug.Log(side);
                break;
            case 2:
                spawnPos = new Vector2(42 - spawnDistance, Random.Range(-7f, 8f));
                Debug.Log(side);
                break;
            case 3:
                spawnPos = new Vector2(-21.6f + spawnDistance, Random.Range(-7f, 8f));
                Debug.Log(side);
                break;
        }
        Instantiate(enemyprefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
