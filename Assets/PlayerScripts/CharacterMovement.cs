using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    float movementAbsolute = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Get movement input from WASD or Arrow Keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the player without rotating
        rb.velocity = movement * movementSpeed * Player.instance.speed;
        movementAbsolute = Math.Abs(movement.x) + Math.Abs(movement.y);
        animator.SetFloat("speed", movementAbsolute);

    }
}
