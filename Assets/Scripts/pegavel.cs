using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegavel : MonoBehaviour
{
    private bool clicando = false;
    private Vector3 offset;
    private float zDist;

    void Update()
    {
        if (clicando)
        {
            // Mantém o objeto na mesma distância da câmera
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zDist;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos + offset;
        }
    }

    private void OnMouseDown()
    {
        clicando = true;

        // Calcula a distância do objeto até a câmera
        zDist = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Converte posição do mouse para mundo e calcula o deslocamento
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDist));
        offset = transform.position - mouseWorldPos;
    }

    private void OnMouseUp()
    {
        clicando = false;
    }
}
