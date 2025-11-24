using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegavel : MonoBehaviour
{
    [TextArea]
    public string descricao; // <<< descrição do objeto

    private bool clicando = false;
    private Vector3 offset;
    private float zDist;

    void Update()
    {
        if (clicando)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zDist;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos + offset;
        }
    }

    private void OnMouseDown()
    {
        clicando = true;

        // Mostra a descrição do objeto
        UIDescricao.Instance.MostrarDescricao(descricao);

        zDist = Vector3.Distance(transform.position, Camera.main.transform.position);

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDist)
        );

        offset = transform.position - mouseWorldPos;
    }

    private void OnMouseUp()
    {
        clicando = false;

        // Esconde a descrição ao soltar
        UIDescricao.Instance.EsconderDescricao();
    }
}
