using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public CameraSystem cameraSystem; // Referencia al sistema de c�maras

    private bool playerInZone = false;  // Estado que indica si el jugador est� dentro de la zona

    // Cuando el jugador entra en la zona de disparo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Si el objeto que entra es el jugador
        {
            playerInZone = true;  // Marca que el jugador est� dentro de la zona
        }
    }

    // Cuando el jugador sale de la zona de disparo
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Si el objeto que sale es el jugador
        {
            playerInZone = false;  // Marca que el jugador ha salido de la zona
        }
    }

    // En cada actualizaci�n del juego
    private void Update()
    {
        if (playerInZone)  // Si el jugador est� dentro de la zona
        {
            if (Input.GetKeyDown(KeyCode.C))  // Si se presiona la tecla "C"
            {
                cameraSystem.ToggleCameraPanel(); // Llama al sistema de c�maras para alternar el panel
            }
        }
    }
}
