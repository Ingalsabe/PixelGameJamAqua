using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject harpoon;
    [SerializeField] private Light2D myLight;

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
        penTiers = 0;
        cooldownTiers = 0;
        lightTiers = 0;
        staminaTiers = 0;
        healthTiers = 0;
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
        if(penTiers < penTiersMax)
        {
            harpoon.GetComponent<HarpoonScript>().IncreasePen();
            HideSystem();
            penTiers++;
            if(penTiers == penTiersMax)
                GameObject.Find("PenetrationUpgradeButton").SetActive(false);
        }
        else
        {
            GameObject.Find("PenetrationUpgradeButton").SetActive(false);
        }
    }

    public void CooldownUpgrade()
    {
        if(cooldownTiers < cooldownTiersMax)
        {
            weapon.GetComponent<WeaponAimScript>().IncreaseWeaponSpeed();
            HideSystem();
            cooldownTiers++;
            if(cooldownTiers == cooldownTiersMax)
                GameObject.Find("SpeedUpgradeButton").SetActive(false);
        }
        else
        {
            GameObject.Find("SpeedUpgradeButton").SetActive(false);
        }
    }

    public void LightLevel()
    {
        if(lightTiers < lightTiersMax)
        {
            myLight.GetComponent<Light2D>().intensity += 0.15f;
            HideSystem();
            lightTiers++;
            if(lightTiers == lightTiersMax)
                GameObject.Find("LightUpgradeButton").SetActive(false);
        }
        else
        {
            GameObject.Find("LightUpgradeButton").SetActive(false);
        }
    }

    public void StaminaLevel()
    {
        if (staminaTiers < staminaTiersMax)
        {
            character.GetComponent<CharacterMovementScript>().DecreaseJumpStamina();
            HideSystem();
            staminaTiers++;
            if(staminaTiers == staminaTiersMax)
                GameObject.Find("StaminaUpgradeButton").SetActive(false);
        }
        else
        {
            GameObject.Find("StaminaUpgradeButton").SetActive(false);
        }
    }

    public void HealthLevel()
    {
        if (healthTiers < healthTiersMax)
        {
            character.GetComponent<PlayerHealth>().IncreaseMaxHealth();
            HideSystem();
            healthTiers++;
            if(healthTiers == healthTiersMax)
                GameObject.Find("HealthUpgradeButton").SetActive(false);
        }
        else
        {
            GameObject.Find("HealthUpgradeButton").SetActive(false);
        }
    }
}
