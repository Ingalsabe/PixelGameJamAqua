using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class FishMoverScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Camera playerCharacter;
    [SerializeField] private float damageCooldown = 1f;
    [SerializeField] private float damageToPlayer = 10f;
    private float timeAfterAttack;
    private bool canAttack = true;

    public int health = 1;

    
    [SerializeField] private GameObject fishDeathPrefab;

    [SerializeField] private Material flashMaterial;
    [SerializeField] private float flashDuration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    void Awake()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }


    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, playerCharacter.transform.position, speed * Time.deltaTime);
        Vector3 currentScale = transform.localScale;

        if (timeAfterAttack < damageCooldown)
        {
            timeAfterAttack += Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }

        if (playerCharacter.transform.position.x < transform.position.x)
        {
            currentScale.x = Mathf.Abs(currentScale.x) * -1;
        }
        else
            currentScale.x = Mathf.Abs(currentScale.x);

        transform.localScale = currentScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damageToPlayer);
            canAttack = false;
            timeAfterAttack = 0f;
        }
    }

    public bool takeDamage()
    {
        health--;
        if (health <= 0)
        {
            Instantiate(fishDeathPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            return true;
        }
        else 
        {
            Flash();
        }
        return false;
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashCoroutine());
    }

}
