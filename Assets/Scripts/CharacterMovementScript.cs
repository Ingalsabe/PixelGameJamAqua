using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    private float verticalMovement;
    private float horizontalMovement;
   
    public float horizontalSpeed = 3f;
    public float upwardSpeed = 6f;

    public GameObject swimAnimationPrefab;

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
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardSpeed);
            Instantiate(swimAnimationPrefab, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * horizontalSpeed, rb.velocity.y);
    }
}
