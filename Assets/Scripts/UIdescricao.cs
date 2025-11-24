using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDescricao : MonoBehaviour
{
    public static UIDescricao Instance;

    public TextMeshProUGUI descricaoTexto;
    public GameObject panelDescricao;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        panelDescricao.SetActive(false);
    }

    public void MostrarDescricao(string texto)
    {
        descricaoTexto.text = texto;
        panelDescricao.SetActive(true);
    }

    public void EsconderDescricao()
    {
        panelDescricao.SetActive(false);
    }
}
