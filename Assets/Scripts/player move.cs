using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermove : MonoBehaviour
{
    public Rigidbody _playerRB;
    Camera _playerCam;

    public LayerMask _ground;

    int speed = 5;
    int lookspeed = 10;
    int pulo = 7;
    

    float mouseX, mouseY;
    Vector3 movedi;

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
        mouseX += Input.GetAxisRaw("Mouse X") * lookspeed;
        mouseY -= Input.GetAxisRaw("Mouse Y") * lookspeed;

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
        // tem que colocar um tempo
        if (Input.GetKeyDown(KeyCode.C))
        {
            speed = 20; // Dobra a velocidade
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            speed = 5; // Volta à velocidade normal ao soltar a tecla
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
}
