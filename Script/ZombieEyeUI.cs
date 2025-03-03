using UnityEngine;

public class ZombieEyeUI : MonoBehaviour
{
    public Transform cameraTransform; // Referencia a la cámara del jugador
    public GameObject eyeIcon; // Referencia al icono del ojo

    void Start()
    {
        eyeIcon.SetActive(false); // Aseguramos que el icono esté apagado al inicio
    }

    void Update()
    {
        // Hacer que el icono siempre mire a la cámara
        if (cameraTransform != null)
        {
            transform.LookAt(cameraTransform);
        }
    }

    public void ShowEye()
    {
        eyeIcon.SetActive(true); // Muestra el icono
    }

    public void HideEye()
    {
        eyeIcon.SetActive(false); // Oculta el icono
    }
}
