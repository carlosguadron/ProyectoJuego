using UnityEngine;

public class SimpleEmergencyButton : MonoBehaviour
{
    public GameObject emergencyImage;  // La imagen que se activa cuando el jugador interactúa
    public KeyCode emergencyKey = KeyCode.E;  // La tecla para activar la emergencia
    public Transform player;  // El jugador que interactúa con el botón

    private bool isImageActive = false;  // Estado de si la imagen de emergencia está activa
    private bool isNearButton = false;  // Estado que indica si el jugador está cerca del botón

    void Update()
    {
        if (isNearButton && Input.GetKeyDown(emergencyKey))  // Si el jugador está cerca del botón y presiona la tecla
        {
            isImageActive = !isImageActive;  // Alterna el estado de la imagen
            emergencyImage.SetActive(isImageActive);  // Activa o desactiva la imagen de emergencia
        }
    }

    // Detecta cuando el jugador entra en el área del botón
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)  // Si el jugador entra en el área del botón
        {
            isNearButton = true;  // Marca que el jugador está cerca del botón
        }
    }

    // Detecta cuando el jugador sale del área del botón
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)  // Si el jugador sale del área del botón
        {
            isNearButton = false;  // Marca que el jugador ya no está cerca
        }
    }
}
