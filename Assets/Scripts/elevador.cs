using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevador : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody fisica;


    public Transform[] PontosRota;
    public int pontoAtual = 0;

    public bool aberto = false;


    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aberto == true)
        {
            Vector3 direcao = PontosRota[pontoAtual].position - transform.position;
            direcao.Normalize(); //faz com que o minimo seja -1 e o masimo seja 1

            fisica.velocity = direcao * velocidade;

            if (Vector2.Distance(transform.position, PontosRota[pontoAtual].position) < 0.2f)
            {
                Debug.Log("chegou");
                pontoAtual++; //soma 1 no ponto atual
                if (pontoAtual >= PontosRota.Length)
                {
                    pontoAtual = 0;//volta para o começo
                }
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //para aqueles que não ta entendendo esta procramação é para o objeto que o player pegar colidir
        // com a porta do elevar e assim abrir
        if (collision.gameObject.CompareTag("objetos"))
        {
            Destroy(collision.gameObject);
            aberto = true;
        }
    }
}
