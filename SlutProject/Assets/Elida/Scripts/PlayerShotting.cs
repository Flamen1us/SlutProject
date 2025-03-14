using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShotting : MonoBehaviour
{
    [SerializeField] float Bulletspeed = 3f;
    [SerializeField] GameObject Bullet;
    void Start()
    {
        
    }

    void OnShoot()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * Bulletspeed, ForceMode2D.Impulse);
    }
   
    void Update()
    {
        
    }
}
