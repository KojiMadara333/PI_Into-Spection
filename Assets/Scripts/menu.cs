using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject _menuObject, _manualMenuObject;

    public bool tempoAtivo = false;

    public playermove playerMoveScript;

    void Start()
    {
        Debug.Log(" odeio voce no fundo da minha alma");

        Time.timeScale = 0.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerMoveScript.enabled = false;
    }

    void Update()
    {
        if (tempoAtivo == true)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void StartButton()
    {
        Time.timeScale = 1.0f;

      //  Cursor.lockState = CursorLockMode.Locked;
     //   Cursor.visible = false;

        playerMoveScript.enabled = true;
        _menuObject.SetActive(false);
    }

    public void ManualButton()
    {
        _menuObject.SetActive(false);

        _manualMenuObject.SetActive(true);
    }

    public void BackButton()
    {
        if(_menuObject.activeSelf == false)
        {
            _manualMenuObject.SetActive(false);

            _menuObject.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void CreditoButton()
    {
        SceneManager.LoadScene("Credit");
    }

    public void inicioButton()
    {
        SceneManager.LoadScene("Game");
    }

}
