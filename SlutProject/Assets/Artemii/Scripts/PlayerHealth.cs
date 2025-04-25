using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int playerHealth = 100;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (playerHealth > 0)
            {
                playerHealth -= 10;
                Debug.Log(playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
