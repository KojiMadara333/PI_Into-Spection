using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopcima : MonoBehaviour
{
    public RectTransform texto;   // arraste o objeto de texto aqui
    public float speed = 50f;

    public float limiteSuperior = 800f;   // posição Y onde o texto "some"
    public float limiteInferior = -800f;  // posição Y de onde ele reaparece

    void Update()
    {
        // Move para cima usando UI (RectTransform)
        texto.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        // Se passou do topo, volta para o início
        if (texto.anchoredPosition.y >= limiteSuperior)
        {
            texto.anchoredPosition = new Vector2(
                texto.anchoredPosition.x,
                limiteInferior
            );
        }
    }
}
