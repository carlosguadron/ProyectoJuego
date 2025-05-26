using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public GameObject panelCameras;  // El panel que se activa y desactiva
    public AmongUsBasicMovement playerMovementScript;  // Referencia al script de movimiento del jugador

    private bool isPanelActive = false;  // Estado que indica si el panel est� activo o no

    void Start()
    {
        panelCameras.SetActive(false);  // Inicializa el panel de c�maras desactivado
    }

    // Funci�n para abrir y cerrar el panel con la tecla C
    public void ToggleCameraPanel()
    {
        isPanelActive = !isPanelActive;  // Alterna el estado del panel
        panelCameras.SetActive(isPanelActive);  // Muestra u oculta el panel seg�n el estado

        if (isPanelActive)
        {
            // Bloquea el movimiento del jugador
            playerMovementScript.enabled = false;  // Desactiva el movimiento del jugador cuando el panel est� activo
        }
        else
        {
            // Habilita el movimiento del jugador
            playerMovementScript.enabled = true;  // Reactiva el movimiento del jugador cuando el panel est� inactivo
        }
    }
}
