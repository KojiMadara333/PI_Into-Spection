using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public LayerMask playerLayer;
    public Rigidbody playerRB;


    void Start()
    {
        Debug.Log("morra  idiota");
    }


    void Update()
    {
      //  float horizontal = Input.GetAxisRaw("Horizontal");
     //  float vertical = Input.GetAxisRaw("Vertical");


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player>().ResetPlayer();
        }
    }
}
