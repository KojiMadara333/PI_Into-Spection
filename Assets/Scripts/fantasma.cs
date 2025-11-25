using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanstama : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody fantasmaRb;
    public Transform posataque;

    [Header("Configurações de Perseguição")]
    public float speed = 4f;
    public float raioataque = 5f;

    [Header("Configurações de Patrulha")]
    public float speedPatrulha = 2f;
    public float tempoTrocaDirecao = 2f;

    // Privadas
    private Transform playerTransform;
    private float raioOriginal;
    private bool jogadorDetectado = false;
    private Vector3 direcaoAleatoria;
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
            Gizmos.color = jogadorDetectado ? Color.red : Color.yellow;
            Gizmos.DrawWireSphere(posataque.position, raioataque);
        }
    }

    void DetectarJogador()
    {
        float distancia = Vector3.Distance(playerTransform.position, posataque.position);
        jogadorDetectado = distancia <= raioataque;

        // Descomente quando adicionar o áudio
        /*if (jogadorDetectado && !audioSource.isPlaying)
            audioSource.Play();
        else if (!jogadorDetectado && audioSource.isPlaying)
            audioSource.Stop();*/
    }

    void PerseguirJogador()
    {
        // Direção para o jogador
        Vector3 direcao = (playerTransform.position - transform.position);
        direcao.y = 0; // Mantém na horizontal

        // Move em direção ao jogador
        fantasmaRb.velocity = direcao.normalized * speed;

        // Rotaciona para olhar o jogador
        if (direcao != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direcao);
        }
    }

    void MovimentoAleatorio()
    {
        cronometroTroca += Time.deltaTime;

        if (cronometroTroca >= tempoTrocaDirecao)
        {
            MudarDirecaoAleatoria();
            cronometroTroca = 0f;
        }

        // Aplica velocidade de patrulha (mais lenta)
        fantasmaRb.velocity = direcaoAleatoria * speedPatrulha;

        // Rotaciona suavemente na direção do movimento
        if (direcaoAleatoria != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direcaoAleatoria);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        }
    }

    void MudarDirecaoAleatoria()
    {
        direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    // Chamado pelo script de movimento do player
    public void playerCorrendo(bool correndo)
    {
        raioataque = correndo ? raioOriginal * 2f : raioOriginal;
    }
}