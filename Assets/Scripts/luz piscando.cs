using UnityEngine;

public class luzpiscando : MonoBehaviour
{
    public Light luz;                // Refer�ncia � _light
    private bool luzLigada = true;  // Estado atual da _light
    private float tempoTotal = 0f;  // Tempo desde o in�cio
    private float intervaloPiscar = 0.5f;  // Intervalo de piscar (em segundos)
    private float tempoPiscar = 0f; // Temporizador para piscar
    private bool comecarPiscar = false; // Controle para iniciar a piscada

    void Update()
    {
        tempoTotal += Time.deltaTime;

        // Espera 7 segundos antes de come�ar a piscar
        if (!comecarPiscar && tempoTotal >= 7f)
        {
            comecarPiscar = true;
            tempoPiscar = 0f;
        }

        // Se passou dos 7 segundos, come�a a piscar
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
