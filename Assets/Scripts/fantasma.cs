using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanstama : MonoBehaviour
{
    public Rigidbody fantasmaRb;
    private Transform playerTransform;
    public float speed = 4;

    // public AudioSource audioSource;

    public float raioataque = 5f;
    public Transform posataque;
    float raioOriginal;

    private bool jogadorDetectado = false;

    // Movimento aleatório
    private Vector3 direcaoAleatoria;
    private float tempoTrocaDirecao = 2f; // tempo entre mudanças de direção
    private float cronometroTroca = 0f;

    void Start()
    {
        raioOriginal = raioataque;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        MudarDirecaoAleatoria();
    }

    void Update()
    {
        DetectarJogador();

        if (jogadorDetectado)
            PerseguirJogador();
        else
            MovimentoAleatorio();

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
            /*if (!audioSource.isPlaying)
                audioSource.Play();*/
        }
        else
        {
            jogadorDetectado = false;
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

        fantasmaRb.velocity = direcaoAleatoria * speed * 0.5f;
    }

    void MudarDirecaoAleatoria()
    {
        direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    // Método chamado pelo jogador
    public void playerCorrendo(bool correndo)
    {
        if (correndo)
            raioataque = raioOriginal * 2f;
        else
            raioataque = raioOriginal;
    }
}
