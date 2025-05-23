using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 screenBoundery;
    float moveSpeed = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Stats stat = FindObjectOfType<Stats>();
        moveSpeed = stat.movementSpeed;
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}
