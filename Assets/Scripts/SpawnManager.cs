using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;

    private float repeatRate = 2;
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    private  Vector3 spawnPos = new Vector3(25, 0, 0);
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        InvokeRepeating(nameof(SpawnCoins), startDelay, repeatRate);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {

            var spawnPos = new Vector3(Random.Range(25, 50), 0, 0);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

        }
        
    }
    private void SpawnCoins()
    {

        if (playerControllerScript.gameOver == false)
        {
            var spawnPos = new Vector3(Random.Range(30,40), 2, 0);
            Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
        }
    }
}
