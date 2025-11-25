using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody playerRB;
    public int life = 5;
    public TextMeshProUGUI vida;
    public float deaths = 0;

    public GameObject telaGameOver;


    void Start()
    {
        telaGameOver.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        vida.text = "vida " + (life);

        if (deaths >= 1)
        {
            vida.text = "vida " + (life);
            GameOver();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void ResetPlayer()
    {
        life -= 1;
        vida.text = "vida " + (life);

        if (life <= 0)
        {
            deaths += 1;
            transform.position = new Vector3(-0.96f, 1f, -16.61f);
            playerRB.velocity = Vector2.zero;
              vida.text = "vida " + (life);
            life = 5;
        }

    }

    public void killPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        telaGameOver.SetActive(true); // ativa a tela de Game Over
        Time.timeScale = 0f; // congela o jogo
    }
}
