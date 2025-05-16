using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigOneEnemy : MonoBehaviour
{
    public float chargeSpeed = 10f;
    public float chargeDuration = 0.5f;
    public float waitBeforeCharge = 1f;
    public float cooldownAfterCharge = 2f;
    public float detectionRange = 5f;

    private Rigidbody2D rb;
    private GameObject player;
    private bool isCharging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!isCharging && Vector2.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            StartCoroutine(ChargeAtPlayer());
        }
    }

    private IEnumerator ChargeAtPlayer()
    {
        isCharging = true;

        // Lock-on delay
        yield return new WaitForSeconds(waitBeforeCharge);

        // Direction at moment of lock-on
        Vector2 direction = (player.transform.position - transform.position).normalized;

        float timer = 0f;

        while (timer < chargeDuration)
        {
            rb.velocity = direction * chargeSpeed;
            timer += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero;

        // Cooldown before next charge
        yield return new WaitForSeconds(cooldownAfterCharge);
        isCharging = false;
    }
}
