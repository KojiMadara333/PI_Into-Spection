using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
  //  private string 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" odeio voce no fundo da minha alma");
       // SceneManager.LoadScene("inicio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogarbuttain()
    {
          SceneManager.LoadScene("jogo");
    }

    public void inicioButtaion()
    {
        SceneManager.LoadScene("inicio");
    }

    public void menuButtaion()
    {
        SceneManager.LoadScene("menu");
    }

    public void manualButtaion()
    {
        SceneManager.LoadScene("manual");
    }

    public void fimButtaion()
    {
        SceneManager.LoadScene("fim");
    }

    public void fase1Buttaion()
    {
        SceneManager.LoadScene("fase1");
    }

    public void fase2Buttaion()
    {
        SceneManager.LoadScene("fase2");
    }

    public void fase3Buttaion()
    {
        SceneManager.LoadScene("fase3");
    }

    public void fase4Buttaion()
    {
        SceneManager.LoadScene("fase4");
    }

    public void fase5Buttaion()
    {
        SceneManager.LoadScene("fase5");
    }

    public void fase6Buttaion()
    {
        SceneManager.LoadScene("fase6");
    }

    public void Sairbuttain()
    {
        Application.Quit();
    }
}
