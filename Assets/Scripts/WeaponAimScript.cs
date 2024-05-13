using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimScript : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    private float timer;

    public bool canFire;
    public float reloadTime = 2f;
    public float harpoonSpeed = 4.5f;
    public GameObject Harpoon;
    public Transform bulletTransform;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > reloadTime)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(Harpoon,bulletTransform.position, Quaternion.Euler(0,0,rotZ + 46));
        }
    }
}
