using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    private float verticalMovement;
    private float horizontalMovement;
    private float timer;
    private float stamina;
    [SerializeField] private int staminaToJump;
    private bool facingRight = true;


    public float horizontalSpeed = 3f;
    public float upwardSpeed = 6f;

    public GameObject swimAnimationPrefab;

    public AudioSource swimSound;

    [SerializeField] private float cooldownStamina = 1.5f;
    [SerializeField] private TMP_Text staminaText;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        staminaText = GameObject.Find("PlayerStaminaText").GetComponent<TextMeshProUGUI>();
        staminaToJump = 25;
        stamina = 100;
        verticalMovement = 0f;
        staminaText.text = "Stamina: " + stamina.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetButtonDown("Jump") && stamina >= staminaToJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardSpeed);
            Instantiate(swimAnimationPrefab, transform.position, Quaternion.identity);
            swimSound.Play(0);
            stamina -= staminaToJump;
            staminaText.text = "Stamina: " + stamina.ToString();
            timer = 0f;
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

        if(stamina < 100)
        {
            timer += Time.deltaTime;
            if(timer > cooldownStamina)
            {
                stamina++;
                staminaText.text = "Stamina: " + stamina.ToString();
            }
            
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        GameObject.Find("Rotation Point").GetComponent<WeaponAimScript>().FlipHarpoon();

        facingRight = !facingRight;
    }

    public void DecreaseJumpStamina()
    {
        staminaToJump -= 5;
    }
}
