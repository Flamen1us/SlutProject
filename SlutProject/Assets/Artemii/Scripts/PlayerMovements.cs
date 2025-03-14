using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    Vector2 moveInput;
    // Start is called before the first frame update

    public void OnRotate()
    {
        transform.Rotate(0,0,45);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveInput*moveSpeed*Time.deltaTime);
    }
}
