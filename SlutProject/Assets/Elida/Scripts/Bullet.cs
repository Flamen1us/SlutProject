using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Stats stat;
    private void Start()
    {
        stat = FindObjectOfType<Stats>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDeath enemy = collision.gameObject.GetComponent<EnemyDeath>();
            if(enemy != null && stat != null)
            {
                enemy.IsDead(stat);
            }
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
