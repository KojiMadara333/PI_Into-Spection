using UnityEngine;

public class laterna : MonoBehaviour
{
    // Referência à _light que será controlada
    public Light _light;

    // Estado da _light (opcional)
    private bool _on = true;

    void Start()
    {
        if (_light == null)
        {
            _light = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Verifica se a tecla L foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Ligar e desligar a luz
            switch (_on)
            {
                case true:
                    _on = false;
                    _light.enabled = false;
                    break;
                case false:
                    _on = true;
                    _light.enabled = true;
                    break;
            }  
        }
    }
}
