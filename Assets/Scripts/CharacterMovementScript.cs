using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    private float verticalMovement;
    private float horizontalMovement;
    private bool facingRight = true;


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

        if(horizontalMovement > 0f && !facingRight)
        {
            Flip();
        }
        if(horizontalMovement < 0f && facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * horizontalSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        GameObject.Find("Rotation Point").GetComponent<WeaponAimScript>().FlipHarpoon();

        facingRight = !facingRight;
    }
}
