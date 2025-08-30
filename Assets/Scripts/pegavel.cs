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
            // Mant�m o objeto na mesma dist�ncia da c�mera
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zDist;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos + offset;
        }
    }

    private void OnMouseDown()
    {
        clicando = true;

        // Calcula a dist�ncia do objeto at� a c�mera
        zDist = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Converte posi��o do mouse para mundo e calcula o deslocamento
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDist));
        offset = transform.position - mouseWorldPos;
    }

    private void OnMouseUp()
    {
        clicando = false;
    }
}
