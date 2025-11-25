using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 5f; // Velocidade do zoom (ajuste conforme desejar)
    [SerializeField] float minZoom = 30f;  // Valor de zoom máximo (mais próximo)
    [SerializeField] float maxZoom = 80f;  // Valor de zoom inicial (mais afastado)

    private Camera cam;
    private float targetZoom; // Valor de destino do zoom

    void Start()
    {
        cam = GetComponent<Camera>();
        // Define o valor inicial do zoom como o valor máximo (posição normal)
        targetZoom = maxZoom;
        if (cam.orthographic)
            cam.orthographicSize = maxZoom;
        else
            cam.fieldOfView = maxZoom;
    }

    void Update()
    {
        // Quando o botão direito estiver pressionado, o zoom vai em direção ao minZoom
        if (Input.GetMouseButton(1))
        {
            targetZoom = minZoom;
        }
        // Quando soltar o botão, o zoom retorna ao valor máximo
        else
        {
            targetZoom = maxZoom;
        }

        // Faz o zoom de forma suave
        if (cam.orthographic)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetZoom, Time.deltaTime * zoomSpeed);
        }
    }
}