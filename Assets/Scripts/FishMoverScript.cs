using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoverScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Camera playerCharacter;

    void Awake()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerCharacter.transform.position, speed * Time.deltaTime);
    }
}
