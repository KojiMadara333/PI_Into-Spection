using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inimigoControle : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody fisica;
  

    public Transform[] PontosRota;
    public int pontoAtual = 0;


    public GameObject fundo;

    public void Tomardano()
    {
       // fundo.SetActive(true);
       // Invoke("desligafundo", 0.2f);


    }

    void desligafundo()
    {
      //  fundo.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcao = PontosRota[pontoAtual].position - transform.position;
        direcao.Normalize(); //faz com que o minimo seja -1 e o masimo seja 1

        fisica.velocity = direcao * velocidade;

      if(Vector2.Distance(transform.position, PontosRota[pontoAtual].position) < 0.2f)
      {
            Debug.Log("chegou");
            pontoAtual++; //soma 1 no ponto atual
            if(pontoAtual >= PontosRota.Length)
            {
                pontoAtual = 0;//volta para o começo
            }
      }
    }
}
