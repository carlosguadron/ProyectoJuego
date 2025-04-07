using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public GameObject panelCameras; // El panel que se activa y desactiva
    public AmongUsBasicMovement playerMovementScript; // Referencia al script de movimiento del jugador

    private bool isPanelActive = false;

    void Start()
    {
        panelCameras.SetActive(false); // Asegurarse de que el panel está desactivado al inicio
    }

    // Función para abrir y cerrar el panel con la tecla C
    public void ToggleCameraPanel()
    {
        isPanelActive = !isPanelActive;
        panelCameras.SetActive(isPanelActive);

        if (isPanelActive)
        {
            // Bloquea el movimiento del jugador
            playerMovementScript.enabled = false;  // Desactiva el movimiento del jugador
        }
        else
        {
            // Habilita el movimiento del jugador
            playerMovementScript.enabled = true;  // Activa el movimiento del jugador
        }
    }
}
