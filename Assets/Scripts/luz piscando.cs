using UnityEngine;

public class luzpiscando : MonoBehaviour
{
    public Light luz;                // Referência à _light
    public bool luzLigada = true;  // Estado atual da _light
    public float tempoTotal = 0f;  // Tempo desde o início
    public float intervaloPiscar = 0.5f;  // Intervalo de piscar (em segundos)
    public float tempoPiscar = 0f; // Temporizador para piscar
    public bool comecarPiscar = false; // Controle para iniciar a piscada

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
