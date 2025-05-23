using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100;
    [SerializeField] public float enemyDamage;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<Stats>().playerHealth;
        Debug.Log(playerHealth);
    }
    private void Update()
    {
        if (playerHealth <= 100)
        {
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (playerHealth > 0)
            {
                playerHealth -= enemyDamage;
                Debug.Log(playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
