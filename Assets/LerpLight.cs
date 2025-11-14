using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Header("Configurations")]
    public Light luz;                  // Referência a luz
    public float minIntensidade = 0.5f; // Intensidade minima
    public float maxIntensidade = 2f;   // Intensidade maxima
    public float velocidade = 3f;       // Velocidade da variação

    private float alvo;                 // Intensidade alvo atual

    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light>();

        alvo = Random.Range(minIntensidade, maxIntensidade);
    }

    void Update()
    {
        // Faz o Lerp da intensidade atual ate o alvo
        luz.intensity = Mathf.Lerp(luz.intensity, alvo, Time.deltaTime * velocidade);

        // Quando a intensidade estiver proxima do alvo, escolhe um novo valor
        if (Mathf.Abs(luz.intensity - alvo) < 0.05f)
        {
            alvo = Random.Range(minIntensidade, maxIntensidade);
        }
    }
}
