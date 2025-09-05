using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanstama : MonoBehaviour
{
    public Rigidbody fantasmaRb;
    public Transform playerTransform;
    int speed = 4;

    public AudioSource audioSource;

    public float raioataque = 8;
    public Transform posataque;

    private bool jogadorDetectado = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            fantasmaRb.velocity = Vector3.zero; // Para o inimigo caso o jogador não tenha sido detectado
        }
    }

    void DetectarJogador()
    {
        float distancia = Vector3.Distance(playerTransform.position, posataque.position);

        if (distancia <= raioataque)
        {
            jogadorDetectado = true;

            // (Opcional) Tocar som ao detectar o jogador pela primeira vez
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
}
