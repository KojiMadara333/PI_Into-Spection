using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persequir : MonoBehaviour
{
    public Rigidbody persequidorRb;
    public Transform playerTransform;
    int speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        persequidorRb.velocity = direction.normalized * speed;

    }
}
