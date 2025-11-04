using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Header("Configurações")]
    public Light luz;                  // Referência à luz
    public float minIntensidade = 0.5f; // Intensidade mínima
    public float maxIntensidade = 2f;   // Intensidade máxima
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
        // Faz o Lerp da intensidade atual até o alvo
        luz.intensity = Mathf.Lerp(luz.intensity, alvo, Time.deltaTime * velocidade);

        // Quando a intensidade estiver próxima do alvo, escolhe um novo valor
        if (Mathf.Abs(luz.intensity - alvo) < 0.05f)
        {
            alvo = Random.Range(minIntensidade, maxIntensidade);
        }
    }
}
