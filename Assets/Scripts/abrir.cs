using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrir : MonoBehaviour
{
    public Rigidbody2D chaveRB;
    bool clicando = false;

    public AudioSource audioSource;
    public AudioClip somDePorta;
    public AudioClip somDeChave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicando)
        {
            audioSource.PlayOneShot(somDeChave);
            Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = posMouse;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("porta"))
        {
            audioSource.PlayOneShot(somDePorta);
            Destroy(collision.gameObject);
            Destroy(gameObject, 2);




        }
    }

    private void OnMouseDown()
    {
        clicando = true; 
    }

    private void OnMouseUp()
    {
        clicando = false;
    }
}
