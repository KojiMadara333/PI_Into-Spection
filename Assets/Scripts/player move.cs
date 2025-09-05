using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;


public class playermove : MonoBehaviour
{
    public Rigidbody _playerRB;
    Camera _playerCam;

    public LayerMask _ground;

    float speed = 5;
    int lookspeed = 10;
    int pulo = 7;
    

    float mouseX, mouseY;
    Vector3 movedi;

    public AudioSource audioSource;

    private float normalSpeed = 5f;
    private float runSpeed = 15f;
    private float tiredSpeed = 2f;
    private float tiredDuration = 4f;
    private bool isTired = false;
    //runSpeed: velocidade enquanto corre.
    //tiredSpeed: velocidade quando está cansado.
    //tiredDuration: tempo que o jogador fica cansado depois de correr.
    //isTired: evita que o jogador corra se ainda estiver cansado.

    // Start is called before the first frame update
        void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //camera
        mouseX += Input.GetAxis("Mouse X") * lookspeed;
        mouseY -= Input.GetAxis("Mouse Y") * lookspeed;

        mouseY = Mathf.Clamp(mouseY, -85, 85);

        // rotacao do player
        transform.rotation = Quaternion.Euler(0, mouseX, 0);

        // cameraRotaion camera
        _playerCam.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);

        // movimeto
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movedi = (transform.forward * moveZ + transform.right * moveX).normalized * speed;

        // pular
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 1.1f, _ground))
        {
            _playerRB.velocity = new Vector3(_playerRB.velocity.x, pulo, _playerRB.velocity.z);
        }

        // correr
        if (Input.GetKeyDown(KeyCode.C) && !isTired)
        {
            speed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.C) && !isTired)
        {
            // Inicia o estado de cansaço
            StartCoroutine(GetTired());
        }

    }

    private void FixedUpdate()
    {
        _playerRB.velocity = new Vector3(movedi.x, _playerRB.velocity.y, movedi.z);
    }

    private void mousetrava()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void mouseaberto()
    {
       Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    IEnumerator GetTired()
    {
        isTired = true;
        speed = tiredSpeed;
        yield return new WaitForSeconds(tiredDuration);
        speed = normalSpeed;
        isTired = false;
    }
}
