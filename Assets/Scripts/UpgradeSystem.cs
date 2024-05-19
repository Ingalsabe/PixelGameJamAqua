using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject harpoon;
    [SerializeField] private GameObject light;

    private int penTiers = 0;
    private int cooldownTiers = 0;
    private int lightTiers = 0;
    private int staminaTiers = 0;
    private int healthTiers = 0;

    private int penTiersMax = 5;
    private int cooldownTiersMax = 3;
    private int lightTiersMax = 2;
    private int staminaTiersMax = 3;
    private int healthTiersMax = 5;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    private void ShowSystem()
    {
        gameObject.SetActive(true);
    }

    private void HideSystem()
    {
        //gameObject.SetActive(false);
    }

    public void PenUpgrade()
    {
        harpoon.GetComponent<HarpoonScript>().IncreasePen();
        HideSystem();
    }

    public void CooldownUpgrade()
    {
        weapon.GetComponent<WeaponAimScript>().IncreaseWeaponSpeed();
        HideSystem();
    }

    public void LightLevel()
    {
        light.GetComponent<Light>().intensity += 0.15f;
        HideSystem();
    }

    public void StaminaLevel()
    {
        character.GetComponent<CharacterMovementScript>().DecreaseJumpStamina();
        HideSystem();
    }

    public void HealthLevel()
    {
        character.GetComponent<PlayerHealth>().IncreaseMaxHealth();
        HideSystem();
    }
}
