using UnityEngine;

public class SimpleEmergencyButton : MonoBehaviour
{
    public GameObject emergencyImage;  // La imagen que quieres mostrar
    public KeyCode emergencyKey = KeyCode.E; // Tecla que quieres usar (por ejemplo, la "E")
    public Transform player; // El jugador que interact�a

    private bool isImageActive = false;
    private bool isNearButton = false;  // Determina si el jugador est� cerca del bot�n

    void Update()
    {
        if (isNearButton && Input.GetKeyDown(emergencyKey))
        {
            isImageActive = !isImageActive; // Cambiar estado de la imagen
            emergencyImage.SetActive(isImageActive);
        }
    }

    // Detectar cuando el jugador entra o sale del �rea del bot�n
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)  // Si el jugador entra en el rango
        {
            isNearButton = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)  // Si el jugador sale del rango
        {
            isNearButton = false;
        }
    }
}
