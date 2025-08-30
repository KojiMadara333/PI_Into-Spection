using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laterna : MonoBehaviour
{
    // Start is called before the first frame update
    // Referência à luz que será controlada
    public Light luz;

    // Estado da luz (opcional)
    private bool luzLigada = true;

    void Start()
    {
        if (luz == null)
        {
            luz = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Verifica se a tecla L foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            luzLigada = !luzLigada;     // Alterna o estado
            luz.enabled = luzLigada;    // Liga ou desliga a luz
        }
    }
}
