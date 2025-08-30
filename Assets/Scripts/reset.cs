using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class reset : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("eu sou AJ");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("fase inicio");
            SceneManager.LoadScene("inicio");
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("sair");
            Application.Quit();
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reset da fase");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
