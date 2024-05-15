using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    [SerializeField]
    private float timeUntilSpawn;

    private bool ableToSpawn = true;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        
        if (timeUntilSpawn <= 0 && ableToSpawn)
        {
            int fishSpawnPercent = Random.Range(0, 100);
            if (fishSpawnPercent >= 90)
            {
                Instantiate(enemyPrefabs[1], transform.position, Quaternion.identity); //Spawn Big Fish
            }
            else if (fishSpawnPercent >= 75)
            {
                Instantiate(enemyPrefabs[2], transform.position, Quaternion.identity); //Spawn Fast Fish
            }
            else
            {
                Instantiate(enemyPrefabs[0], transform.position, Quaternion.identity); //Spawn Normal Fish
            }
            SetTimeUntilSpawn();
        }
        else if(timeUntilSpawn <= 0)
        {
            timeUntilSpawn = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log(collision.gameObject.name);
            //Debug.Log("test");
            ableToSpawn = false;
        }
    }

    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ableToSpawn = true;
        }
    }

    private void SetTimeUntilSpawn()
    { 
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
