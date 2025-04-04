using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyprefab;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] float spawnDistance = 10f;
    [SerializeField] float spawnLeftBorderX = 0;
    [SerializeField] float spawnRightBorderX = 0;
    [SerializeField] float spawnUpBorder = 0;
    [SerializeField] float spawnDownBorder = 0;
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
                spawnPos = new Vector2(Random.Range(spawnLeftBorderX, spawnRightBorderX), spawnUpBorder + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(spawnLeftBorderX, spawnRightBorderX), spawnDownBorder - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(spawnLeftBorderX - spawnDistance, Random.Range(spawnDownBorder, spawnUpBorder));
                break;
            case 3:
                spawnPos = new Vector2(spawnRightBorderX + spawnDistance, Random.Range(spawnDownBorder, spawnUpBorder));
                break;
        }
        Instantiate(enemyprefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
