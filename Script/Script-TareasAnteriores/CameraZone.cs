using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public CameraSystem cameraSystem; // Referencia al sistema de c�maras

    private bool playerInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.C))  // Cambiar a la tecla C
            {
                cameraSystem.ToggleCameraPanel(); // Llamar a la funci�n que activa/desactiva el panel
            }
        }
    }
}
