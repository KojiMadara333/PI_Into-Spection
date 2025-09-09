using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanstama : MonoBehaviour
{
    public Rigidbody fantasmaRb;
    private Transform playerTransform;
    public float speed = 4;

    public AudioSource audioSource;

    public float raioataque = 5f;
    public Transform posataque;

    private bool jogadorDetectado = false;

    // Movimento aleatório
    private Vector3 direcaoAleatoria;
    private float tempoTrocaDirecao = 2f; // tempo entre mudanças de direção
    private float cronometroTroca = 0f;

    void Start()
    {
        // Define uma direção inicial aleatória

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        MudarDirecaoAleatoria();
    }

    void Update()
    {
        DetectarJogador();

        if (jogadorDetectado)
        {
            PerseguirJogador();
        }
        else
        {
            MovimentoAleatorio();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (posataque != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(posataque.position, raioataque);
        }
    }


    void DetectarJogador()
    {
        float distancia = Vector3.Distance(playerTransform.position, posataque.position);

        if (distancia <= raioataque)
        {
            jogadorDetectado = true;

            // (Opcional) Tocar som ao detectar o jogador
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    void PerseguirJogador()
    {
        Vector3 direcao = (playerTransform.position - transform.position).normalized;
        fantasmaRb.velocity = direcao * speed;
    }

    void MovimentoAleatorio()
    {
        cronometroTroca += Time.deltaTime;

        if (cronometroTroca >= tempoTrocaDirecao)
        {
            MudarDirecaoAleatoria();
            cronometroTroca = 0f;
        }

        fantasmaRb.velocity = direcaoAleatoria * speed * 0.5f; // move mais devagar no modo aleatório
    }

    void MudarDirecaoAleatoria()
    {
        // Cria uma direção aleatória no plano XZ (horizontal)
        direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
