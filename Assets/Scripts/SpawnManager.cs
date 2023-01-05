using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject[] obstacles;

    private PlayerController playerControllerScript;
    private Vector3 spawnPosition = new Vector3(25, 1, 0);
    private float startDelay = 2f;
    private float repeatRate = 3f;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if(playerControllerScript.GetGameOver() == false)
        {
            int index = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[index], spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
