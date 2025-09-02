using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morte : MonoBehaviour
{
    public LayerMask playerLayer;
    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player>().killPlayer();
        }
    }
}
