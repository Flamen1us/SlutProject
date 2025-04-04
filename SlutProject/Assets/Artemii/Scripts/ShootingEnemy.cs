using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float enemySpeed = 2f;
    Rigidbody2D rb;
    bool haveShooted = false;
    GameObject player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    private IEnumerator Shoot()
    {
        if (bulletPrefab == null) yield return null;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if(rb != null && !haveShooted)
        {
            Vector2 direction = (player.transform.position - firePoint.position).normalized;
            rb.velocity = direction * bulletSpeed;
            haveShooted = true;
        }
        Debug.Log("Waiting until next shoot");
        yield return new WaitForSeconds(5f);
        haveShooted = false;
        Debug.Log("Ready to shoot");
    }
    // Update is called once per frame
    void Update()
    {
        if (haveShooted && player != null)
        {
            Vector2 direction = ((-player.transform.position) - transform.position).normalized;
            Debug.Log(direction);
            rb.MovePosition(rb.position + direction*enemySpeed*Time.deltaTime);
            Debug.Log("Walking");
        }
        if (!haveShooted)
        {
            StartCoroutine(Shoot());
        }
    }
}
