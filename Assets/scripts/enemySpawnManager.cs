using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnManager : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject eliteEnemy;
    public GameObject[] enemies;
    public int randomEnemy;
    public float spawnInterval;
    private float waitTime;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        waitTime = spawnInterval;
        SpawnRandomEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.status == false)
        {
            if (waitTime <= 0)
            {
                SpawnRandomEnemy();
                waitTime = spawnInterval;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemies in enemies)
            {
                Destroy(enemies);
            }
        }
        
    }

    void SpawnRandomEnemy()
    {
        randomEnemy = Random.Range(0, 2);
        if (randomEnemy == 0)
        {
            SpawnBasicEnemy();
        }
        else if(randomEnemy == 1)
        {
            SpawnEliteEnemy();
        }
    }


    void SpawnBasicEnemy()
    {
        Instantiate(basicEnemy, basicEnemy.transform.position, Quaternion.Euler(0, 0, 90));
    }

    void SpawnEliteEnemy()
    {
        Instantiate(eliteEnemy, eliteEnemy.transform.position, Quaternion.Euler(0, 0, 90));
    }
}