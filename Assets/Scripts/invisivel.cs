using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisivel : MonoBehaviour
{
    private Renderer rend;
    private bool isInvisible = false;
    private float nextInvisibilityTime = 0f;

    public float invisibilityDuration = 2f;  // tempo em segundos
    public float invisibilityCooldown = 5f;  // tempo entre as invisibilidades

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();  // pega o Renderer do objeto
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se é hora de ficar invisível novamente
        if (Time.time >= nextInvisibilityTime && !isInvisible)
        {
            StartCoroutine(FicarInvisivelTemporariamente());
        }
    }

    IEnumerator FicarInvisivelTemporariamente()
    {
        isInvisible = true;
        rend.enabled = false;  // deixa invisível

        yield return new WaitForSeconds(invisibilityDuration);

        rend.enabled = true;  // volta a ficar visível
        nextInvisibilityTime = Time.time + invisibilityCooldown;
        isInvisible = false;
    }
}
