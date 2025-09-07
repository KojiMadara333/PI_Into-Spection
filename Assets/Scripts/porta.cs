using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    private bool isRotating = false;
    private Quaternion targetRotation;

   // public AudioSource audioSource;

    void Update()
    {
        // Detecta o clique do mouse
        if (Input.GetMouseButtonDown(0) && !isRotating)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica se o objeto foi clicado
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    // Define a nova rotação alvo (90 graus a mais no eixo Y)
                    targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0));
                    isRotating = true;
                }
            }
        }

        // Faz a rotação suave até a nova rotação
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }
}
