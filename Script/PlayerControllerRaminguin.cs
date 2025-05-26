using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControllerRaminguin : MonoBehaviour
{
    
    public float moveSpeed = 5f;        //Velocidad de movimiento.
    public float mouseSensitivity = 2f; //Sensibilidad del mouse.
    public Transform playerCamera;      //C�mara en primera persona.
    public Transform thirdPersonCam;    //C�mara en tercera persona.
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float rotationX = 0;
    private bool isFirstPerson = true; //Estado actual de la c�mara.

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor en el centro de la pantalla.

    }

    void Update()
    {
        HandleMovement();
        HandleCameraRotation();
        HandleCameraSwitch();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D o Flechas Izq/Der
        float moveZ = Input.GetAxis("Vertical");   // W/S o Flechas Arriba/Abajo

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limita la rotaci�n en el eje X para no dar giros extra�os

        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Rotaci�n vertical
        transform.Rotate(Vector3.up * mouseX); // Rotaci�n horizontal
    }

    void HandleCameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Presiona "C" para alternar entre c�maras
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
            {
                playerCamera.gameObject.SetActive(true);
                thirdPersonCam.gameObject.SetActive(false);
            }
            else
            {
                playerCamera.gameObject.SetActive(false);
                thirdPersonCam.gameObject.SetActive(true);
            }
        }
    }
}
