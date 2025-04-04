using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 screenBoundery;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotationSpeed = 4000;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotate);
        }
        else
        {
            rb.angularVelocity = 0;
        }

        screenBoundery = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundery.x, screenBoundery.x), Mathf.Clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));
    }
}
