using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    private float verticalMovement;
    private float horizontalMovement;
    private float horizontalSpeed = 6f;
    private float upwardSpeed = 12f;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        verticalMovement = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardSpeed);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * horizontalSpeed, rb.velocity.y);
    }
}
