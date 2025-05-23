using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShotting : MonoBehaviour
{
    [SerializeField] public float Bulletspeed = 5f;
    [SerializeField] GameObject Bullet;
    void Update()
    {
        Mouseaime();
    }

    public void Mouseaime()
    {
        //Get mouse posision for aim, player look at mouse then pew pew 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;
        //Get the direction :)
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    void OnShoot()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Debug.Log("Shoot");
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * Bulletspeed, ForceMode2D.Impulse); 
    }
   
   
}
