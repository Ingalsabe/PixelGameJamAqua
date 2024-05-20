using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimScript : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    private float timer;
    private bool weaponIsFlipped;

    [SerializeField] private GameObject progBar;
    [SerializeField] GameObject Harpoon;
    [SerializeField] GameObject weapon;

    public bool canFire;
    public float reloadTime = 1.5f;
    public float harpoonSpeed = 4.5f;
    public Transform bulletTransform;

    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        reloadTime = 1.5f;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Harpoon.GetComponent<HarpoonScript>().penetration = 1;
        progBar.SetActive(false);
        weaponIsFlipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        Vector3 currentScale = progBar.transform.localScale;

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;

            currentScale.x = timer * (0.01f / (reloadTime / 15));
            progBar.transform.localScale = currentScale;

            if (timer > reloadTime)
            {
                canFire = true;
                timer = 0;
                progBar.SetActive(false);
                currentScale.x = 0f;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            progBar.SetActive(true);
            Instantiate(Harpoon,bulletTransform.position, Quaternion.Euler(0,0,rotZ + 46));
            shootSound.Play(0);
        }

        if(!weaponIsFlipped && (gameObject.transform.eulerAngles.z <= -90 || gameObject.transform.eulerAngles.z > 90))
        {
            //flipWeapon();
            weaponIsFlipped = true;
        }
        else if (weaponIsFlipped && (gameObject.transform.eulerAngles.z > -90 || gameObject.transform.eulerAngles.z <= 90))
        {
            //flipWeapon();
            weaponIsFlipped = false;
        }
    }

    public void FlipHarpoon()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }

    private void flipWeapon()
    {
        Quaternion currentRotation = weapon.transform.rotation;
        if (weapon.transform.rotation.z == 30)
            currentRotation.z = -150;
        else
            currentRotation.z = 30;
        weapon.transform.rotation = currentRotation;
    }

    public void IncreaseWeaponSpeed()
    {
        reloadTime -= 0.3f;
    }
}
