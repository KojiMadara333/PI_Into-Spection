using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luzpiscando : MonoBehaviour
{
    public Light luz;                // Referência à luz
    private bool luzLigada = true;  // Estado atual da luz
    private float tempoTotal = 0f;  // Tempo desde o início
    private float intervaloPiscar = 0.5f;  // Intervalo de piscar (em segundos)
    private float tempoPiscar = 0f; // Temporizador para piscar
    private bool comecarPiscar = false; // Controle para iniciar a piscada

    void Start()
    {
        if (luz == null)
        {
            luz = GetComponent<Light>();
        }
    }

    void Update()
    {
        tempoTotal += Time.deltaTime;

        // Espera 7 segundos antes de começar a piscar
        if (!comecarPiscar && tempoTotal >= 7f)
        {
            comecarPiscar = true;
            tempoPiscar = 0f;
        }

        // Se passou dos 7 segundos, começa a piscar
        if (comecarPiscar)
        {
            tempoPiscar += Time.deltaTime;

            if (tempoPiscar >= intervaloPiscar)
            {
                luzLigada = !luzLigada;
                luz.enabled = luzLigada;
                tempoPiscar = 0f;
            }
        }
    }
}
