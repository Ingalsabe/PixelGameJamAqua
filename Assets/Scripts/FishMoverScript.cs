using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FishMoverScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Camera playerCharacter;
    [SerializeField] private float damageCooldown = 1f;
    [SerializeField] private float damageToPlayer = 10f;
    private float timeAfterAttack;
    private bool canAttack = true;

    void Awake()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damageToPlayer);
            canAttack = false;
            timeAfterAttack = 0f;
        }
    }
}
