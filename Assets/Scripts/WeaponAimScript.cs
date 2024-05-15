using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimScript : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    private float timer;

    [SerializeField] private GameObject progBar;

    public bool canFire;
    public float reloadTime = 1.5f;
    public float harpoonSpeed = 4.5f;
    public GameObject Harpoon;
    public Transform bulletTransform;

    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        progBar.SetActive(false);
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

            currentScale.x = timer * 0.1f;
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
    }

    public void FlipHarpoon()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
