using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinpickup : MonoBehaviour
{
    public int Coinvalue = 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
