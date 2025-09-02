using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody playerRB;
    int life = 5;
    public TextMeshProUGUI vida;
    public float deaths = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "vida " + (life);

        if (deaths >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void ResetPlayer()
    {
        life -= 1;
        

        if (life <= 0)
        {
            deaths += 1;
            transform.position = new Vector3(0, 0, 0);
            playerRB.velocity = Vector2.zero;
            //  morte.text = "morte " + (deaths);
            life = 5;
        }

    }

    public void killPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
