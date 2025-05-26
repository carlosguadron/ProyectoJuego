using UnityEngine;

public class SimpleEmergencyButton : MonoBehaviour
{
    public GameObject emergencyImage;  // La imagen que se activa cuando el jugador interact�a
    public KeyCode emergencyKey = KeyCode.E;  // La tecla para activar la emergencia
    public Transform player;  // El jugador que interact�a con el bot�n

    private bool isImageActive = false;  // Estado de si la imagen de emergencia est� activa
    private bool isNearButton = false;  // Estado que indica si el jugador est� cerca del bot�n

    void Update()
    {
        if (isNearButton && Input.GetKeyDown(emergencyKey))  // Si el jugador est� cerca del bot�n y presiona la tecla
        {
            isImageActive = !isImageActive;  // Alterna el estado de la imagen
            emergencyImage.SetActive(isImageActive);  // Activa o desactiva la imagen de emergencia
        }
    }

    // Detecta cuando el jugador entra en el �rea del bot�n
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)  // Si el jugador entra en el �rea del bot�n
        {
            isNearButton = true;  // Marca que el jugador est� cerca del bot�n
        }
    }

    // Detecta cuando el jugador sale del �rea del bot�n
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)  // Si el jugador sale del �rea del bot�n
        {
            isNearButton = false;  // Marca que el jugador ya no est� cerca
        }
    }
}
