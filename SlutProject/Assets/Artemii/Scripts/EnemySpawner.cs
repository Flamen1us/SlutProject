using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDistance = 10f;
    [SerializeField] float spawnLeftBorder = 0;
    [SerializeField] float spawnRightBorder = 0;
    [SerializeField] float spawnUpBorder = 0;
    [SerializeField] float spawnDownBorder = 0;
    public int waveNumber = 1;
    [SerializeField] GameObject normalEnemy;
    [SerializeField] GameObject cowardEnemy;
    [SerializeField] GameObject fastEnemy;
    [SerializeField] GameObject BigOneEnemy;
    [SerializeField] PlayerHealth pla;
    [SerializeField] EnemyDeath enemyHP;
    [SerializeField] EnemyDeath fastHP;
    [SerializeField] EnemyDeath cowardHP;
    [SerializeField] EnemyDeath BigOneHP;
    Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        waveNumber = FindObjectOfType<Stats>().waveNumber;
        Debug.Log(waveNumber);
        pla.enemyDamage = 5;
        enemyHP.enemyHealth = 3 + Mathf.Pow(1.1f, waveNumber);
        fastHP.enemyHealth = 1 + Mathf.Pow(1.2f, waveNumber);
        cowardHP.enemyHealth = 5 + Mathf.Pow(1.05f,waveNumber);
        BigOneHP.enemyHealth = 10 + Mathf.Pow(1.3f, waveNumber);
        switch (waveNumber)
        {
            case 1:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 1, 3));
                break;
            case 2:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 1, 3));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 1, 2));
                pla.enemyDamage = 6;
                break;
            case 3:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.5f, 2));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 1, 2));
                pla.enemyDamage = 8;
                break;
            case 4:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.5f, 2));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.5f, 1.5f));
                StartCoroutine(SpawnEnemyLoop(cowardEnemy, 1, 2));
                pla.enemyDamage = 10;
                break;
            case 5:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.5f, 1.5f));
                StartCoroutine(SpawnEnemyLoop(cowardEnemy, 0.75f, 1.75f));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.3f, 1));
                pla.enemyDamage = 13;
                break;
            case 6:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.5f, 1.4f));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.5f, 0.9f));
                StartCoroutine(SpawnEnemyLoop(BigOneEnemy, 1, 2));
                pla.enemyDamage = 17;
                break;
            case 7:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.4f, 1.3f));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.8f, 1.4f));
                StartCoroutine(SpawnEnemyLoop(BigOneEnemy, 1, 1.75f));
                StartCoroutine(SpawnEnemyLoop(cowardEnemy, 0.6f, 1.3f));
                pla.enemyDamage = 20;
                break;
            case 8:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.3f, 1.2f));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.5f, 1));
                StartCoroutine(SpawnEnemyLoop(BigOneEnemy, 0.8f, 1.4f));
                StartCoroutine(SpawnEnemyLoop(cowardEnemy, 0.6f, 1.2f));
                pla.enemyDamage = 25;
                break;
            case 9:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.2f, 0.9f));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.5f, 0.9f));
                StartCoroutine(SpawnEnemyLoop(cowardEnemy, 0.6f, 1.2f));
                StartCoroutine(SpawnEnemyLoop(BigOneEnemy, 0.8f, 1.2f));
                pla.enemyDamage = 30;
                break;
            case 10:
                StartCoroutine(SpawnEnemyLoop(normalEnemy, 0.1f, 0.5f));
                StartCoroutine(SpawnEnemyLoop(fastEnemy, 0.4f, 0.9f));
                StartCoroutine(SpawnEnemyLoop(cowardEnemy, 0.6f, 1.2f));
                StartCoroutine(SpawnEnemyLoop(BigOneEnemy, 0.7f, 1));
                pla.enemyDamage = 40;
                break;
        }
    }

    IEnumerator SpawnEnemyLoop(GameObject enemyprefab, float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = Random.Range(minTime,maxTime);
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy(enemyprefab);
        }
    }
    // Update is called once per frame
    void SpawnEnemy(GameObject enemyprefab)
    {
        
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
    }
}
