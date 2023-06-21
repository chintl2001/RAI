using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnerController : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3, Ground4;
    bool hasGround = true;
    // Start is called before the first frame update
    void Start()
    {
            SpawnGround();
        Debug.Log("Start");

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
            Debug.Log("Update");
        }
    }

    public void SpawnGround()
    {
        int randomNum = UnityEngine.Random.Range(1, 5);
        float groundOffset = 5f; // Khoảng cách giữa các ground

        if (randomNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + groundOffset, -4.66f, 0), Quaternion.identity);
        }
        else if (randomNum == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x + groundOffset * 1.5f, -8.2f, 0), Quaternion.identity);
        }
        else if (randomNum == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x + groundOffset, 6.12f, 0), Quaternion.identity);
        }
        else if (randomNum == 4)
        {
            Instantiate(Ground4, new Vector3(transform.position.x + groundOffset * 1.2f, -4.55f, 0), Quaternion.identity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            hasGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            hasGround = false;
        }
    }
}
