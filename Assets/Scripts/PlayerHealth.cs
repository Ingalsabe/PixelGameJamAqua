using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] TMP_Text healthText;
    private float health;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;
        health = maxHealth;
        healthText = GameObject.Find("PlayerHealthText").GetComponent<TextMeshProUGUI>();
        healthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;
        healthText.text = "Health: " + health.ToString();
    }

    public void IncreaseMaxHealth()
    {
        maxHealth += 20f;
    }
}
