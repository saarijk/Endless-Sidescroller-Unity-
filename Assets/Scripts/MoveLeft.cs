using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    private PlayerController playerControllerScript;
    private float leftBound = -15;

    private void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerControllerScript.GetGameOver() == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    public float GetSpeed()
    {
        return speed;
    }
}
