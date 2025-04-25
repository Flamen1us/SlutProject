using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weponup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

       
    }

    public void Update()
    {
        
    }
}
