using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinpickup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Player"))
        {
            HuD hud = FindObjectOfType<HuD>();
            if (hud != null)
            {
                hud.AddCoin();
            }
            Destroy(gameObject);
        }
    }
}
