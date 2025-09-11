using UnityEngine;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject _menuObject, _manualMenuObject;

    void Start()
    {
        Debug.Log(" odeio voce no fundo da minha alma");

        Time.timeScale = 0.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartButton()
    {
        Time.timeScale = 1.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

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
}
