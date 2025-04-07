using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    public Camera[] cameras;         // Lista de cámaras en el juego
    public Image cameraFeedUI;       // Imagen de la UI donde se mostrará la cámara
    public KeyCode interactKey = KeyCode.C;  // Tecla para interactuar con las cámaras
    private int currentCameraIndex = 0;      // Índice de la cámara actual

    void Start()
    {
        // Desactiva todas las cámaras al inicio
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Desactiva la UI al inicio
        cameraFeedUI.gameObject.SetActive(false);
    }

    void Update()
    {
        // Si presionamos la tecla interactKey (por ejemplo, "C") y hay cámaras disponibles
        if (Input.GetKeyDown(interactKey) && cameras.Length > 0)
        {
            // Activar la UI de cámaras
            cameraFeedUI.gameObject.SetActive(true);

            // Desactivar la cámara actual
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Cambiar a la siguiente cámara
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Activar la nueva cámara
            cameras[currentCameraIndex].gameObject.SetActive(true);

            // Actualizar el feed de la UI (este ejemplo simplemente cambia el color de la imagen como un placeholder)
            cameraFeedUI.color = Random.ColorHSV();  // Puedes reemplazarlo por una textura real más tarde
        }
    }
}
