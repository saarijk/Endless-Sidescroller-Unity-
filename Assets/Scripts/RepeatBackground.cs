using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startingPosition;
    private float repeatWidth;

    private void Start()
    {
        startingPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < startingPosition.x - repeatWidth) {
            transform.position = startingPosition;
        }
    }
}
