using System.Collections;
using UnityEngine;


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
    private float runSpeed = 15f; //Velocidade enquanto corre.

    private float tiredSpeed = 2f; //Velocidade quando está cansado.
    private float tiredDuration = 4f;//Tempo que o jogador fica cansado depois de correr.

    private bool isTired = false; //Evita que o jogador corra se ainda estiver cansado.

    // Start is called before the first frame update
    void Start()
    {
        _playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        mouseX += Input.GetAxisRaw("Mouse X") * lookspeed;
        mouseY -= Input.GetAxisRaw("Mouse Y") * lookspeed;

        mouseY = Mathf.Clamp(mouseY, -85, 85);

        //Rotacao do player
        transform.rotation = Quaternion.Euler(0, mouseX, 0);

        //CameraRotaion camera
        _playerCam.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);

        //Movimeto
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movedi = (transform.forward * moveZ + transform.right * moveX).normalized * speed;

        //Pular
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 1.1f, _ground))
        {
            _playerRB.velocity = new Vector3(_playerRB.velocity.x, pulo, _playerRB.velocity.z);
        }

        //Correr
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isTired)
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
