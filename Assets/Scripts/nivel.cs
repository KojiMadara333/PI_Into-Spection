using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nivel : MonoBehaviour
{
    public bool fase1 = false;
    public bool fase2 = false;
    public bool fase3 = false;
    public bool venceu = false;

    public GameObject telaDeVitoria;

    // Start is called before the first frame update
    void Start()
    {
        telaDeVitoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // me pediram para fazer um negocio que quando o player colide passar de fase
        // mas pelo que eu entedi vai ter mais de uma fase então eu fiz isso
        // voce pode escolher qual fase sera quando colidir

        if (fase1 == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("Game1");//coloca o nome da cena ai
            }
        }
        if (fase2 == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("");//coloca o nome da cena ai
            }
        }
        if (fase3 == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("");//coloca o nome da cena ai
            }
        }

        if (venceu == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                telaDeVitoria.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

    }
}
