using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float minSpawnTime = 1f;
    float maxSpawnTime = 3f;
    [SerializeField] float spawnDistance = 10f;
    [SerializeField] float spawnLeftBorder = 0;
    [SerializeField] float spawnRightBorder = 0;
    [SerializeField] float spawnUpBorder = 0;
    [SerializeField] float spawnDownBorder = 0;
    [SerializeField] int waveNumber = 1;
    [SerializeField] GameObject normalEnemy;
    [SerializeField] GameObject cowardEnemy;
    [SerializeField] GameObject fastEnemy;
    [SerializeField] GameObject BigOneEnemy;
    Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        switch (waveNumber)
        {
            case 1:
                SpawnEnemy(normalEnemy, 1, 3);
                break;
            case 2:
                SpawnEnemy(normalEnemy, 1, 3);
                SpawnEnemy(fastEnemy, 1, 2);
                break;
            case 3:
                SpawnEnemy(normalEnemy, 0.5f, 2);
                SpawnEnemy(fastEnemy, 1, 2);
                break;
            case 4:
                SpawnEnemy(normalEnemy, 0.5f, 2);
                SpawnEnemy(fastEnemy, 0.5f, 1.5f);
                SpawnEnemy(cowardEnemy, 1, 2);
                break;
            case 5:
                SpawnEnemy(normalEnemy, 0.5f, 1.5f);
                SpawnEnemy(cowardEnemy, 0.75f, 1.75f);
                SpawnEnemy(fastEnemy, 0.3f, 1);
                break;
            case 6:
                SpawnEnemy(normalEnemy, 0.5f, 1.4f);
                SpawnEnemy(fastEnemy, 0.5f, 0.9f);
                SpawnEnemy(BigOneEnemy, 1, 2);
                break;
            case 7:
                SpawnEnemy(normalEnemy, 0.4f, 1.3f);
                SpawnEnemy(fastEnemy, 0.8f, 1.4f);
                SpawnEnemy(BigOneEnemy, 1, 1.75f);
                SpawnEnemy(cowardEnemy, 0.6f, 1.3f);
                break;
            case 8:
                SpawnEnemy(normalEnemy, 0.3f, 1.2f);
                SpawnEnemy(fastEnemy, 0.5f, 1);
                SpawnEnemy(BigOneEnemy, 0.8f, 1.4f);
                SpawnEnemy(cowardEnemy, 0.6f, 1.2f);
                break;
            case 9:
                SpawnEnemy(normalEnemy, 0.2f, 0.9f);
                SpawnEnemy(fastEnemy, 0.5f, 0.9f);
                SpawnEnemy(cowardEnemy, 0.6f, 1.2f);
                SpawnEnemy(BigOneEnemy, 0.8f, 1.2f);
                break;
            case 10:
                SpawnEnemy(normalEnemy, 0.1f, 0.5f);
                SpawnEnemy(fastEnemy, 0.4f, 0.9f);
                SpawnEnemy(cowardEnemy, 0.6f, 1.2f);
                SpawnEnemy(BigOneEnemy, 0.7f, 1);
                break;
        }
    }

    // Update is called once per frame
    void SpawnEnemy(GameObject enemyprefab, float minSpawnTime, float maxSpawnTime)
    {
        
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(spawnLeftBorder, spawnRightBorder), spawnUpBorder + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(spawnLeftBorder, spawnRightBorder), spawnDownBorder - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(spawnLeftBorder - spawnDistance, Random.Range(spawnDownBorder, spawnUpBorder));
                break;
            case 3:
                spawnPos = new Vector2(spawnRightBorder + spawnDistance, Random.Range(spawnDownBorder, spawnUpBorder));
                break;
        }
        Instantiate(enemyprefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
