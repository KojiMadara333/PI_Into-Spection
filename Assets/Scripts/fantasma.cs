using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanstama : MonoBehaviour
{
    public Rigidbody fantasmaRb;
    public Transform playerTransform;
    public float speed = 6;


    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        fantasmaRb.velocity = direction.normalized * speed;

        // Rotaciona no eixo Y para olhar para o player (mantém na horizontal)
        Vector3 lookDirection = direction;
        lookDirection.y = 0; // Ignora a diferença de altura

        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}