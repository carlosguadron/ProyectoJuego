using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public GameObject panelCameras;  // El panel que se activa y desactiva
    public AmongUsBasicMovement playerMovementScript;  // Referencia al script de movimiento del jugador

    private bool isPanelActive = false;  // Estado que indica si el panel está activo o no

    void Start()
    {
        panelCameras.SetActive(false);  // Inicializa el panel de cámaras desactivado
    }

    // Función para abrir y cerrar el panel con la tecla C
    public void ToggleCameraPanel()
    {
        isPanelActive = !isPanelActive;  // Alterna el estado del panel
        panelCameras.SetActive(isPanelActive);  // Muestra u oculta el panel según el estado

        if (isPanelActive)
        {
            // Bloquea el movimiento del jugador
            playerMovementScript.enabled = false;  // Desactiva el movimiento del jugador cuando el panel está activo
        }
        else
        {
            // Habilita el movimiento del jugador
            playerMovementScript.enabled = true;  // Reactiva el movimiento del jugador cuando el panel está inactivo
        }
    }
}
