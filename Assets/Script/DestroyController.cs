using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{

    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5;
    }
    private void Update()
    {
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
