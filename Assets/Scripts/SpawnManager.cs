using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    private PlayerController playerControllerScript;
    private Vector3 spawnPosition = new Vector3(25, 1, 0);
    private float startDelay = 2f;
    private float repeatRate = 2f;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if(playerControllerScript.GetGameOver() == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
