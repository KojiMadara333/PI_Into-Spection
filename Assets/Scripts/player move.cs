using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class playermove : MonoBehaviour
{
    public Rigidbody playerRB;
    public Camera camerapl;
    public LayerMask piso;
    int speed = 5;
    int lookspeed = 10;
    int pulo = 7;
    

    float mouseX, mouseY;
    Vector3 movedi;

    // Start is called before the first frame update
    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false;
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

        // ratacao camera
        camerapl.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);

        // movimeto
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movedi = (transform.forward * moveZ + transform.right * moveX).normalized * speed;

        //pular
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 1.1f, piso))
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, pulo, playerRB.velocity.z);
        }
     
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector3(movedi.x, playerRB.velocity.y, movedi.z);
    }


    private void mousetrava()
    {
       // Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false;
    }

    private void mouseaberto()
    {
       Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
