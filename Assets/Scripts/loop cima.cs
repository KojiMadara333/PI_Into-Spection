using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopcima : MonoBehaviour
{
    public Rigidbody2D objetoRB;
    int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        objetoRB.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 20)
        {
            transform.position = new Vector3(0, -20, 0);
        }
    }
}
