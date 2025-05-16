using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] float enemyHealth = 4;
    [SerializeField] GameObject coin;
    public void IsDead(Stats stat)
    {
        enemyHealth -= stat.damage;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(coin, transform.position, transform.rotation);
        }
    }
}
