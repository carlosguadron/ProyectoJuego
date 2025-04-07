using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    public Camera[] cameras;         // Lista de c�maras en el juego
    public Image cameraFeedUI;       // Imagen de la UI donde se mostrar� la c�mara
    public KeyCode interactKey = KeyCode.C;  // Tecla para interactuar con las c�maras
    private int currentCameraIndex = 0;      // �ndice de la c�mara actual

    void Start()
    {
        // Desactiva todas las c�maras al inicio
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Desactiva la UI al inicio
        cameraFeedUI.gameObject.SetActive(false);
    }

    void Update()
    {
        // Si presionamos la tecla interactKey (por ejemplo, "C") y hay c�maras disponibles
        if (Input.GetKeyDown(interactKey) && cameras.Length > 0)
        {
            // Activar la UI de c�maras
            cameraFeedUI.gameObject.SetActive(true);

            // Desactivar la c�mara actual
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Cambiar a la siguiente c�mara
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Activar la nueva c�mara
            cameras[currentCameraIndex].gameObject.SetActive(true);

            // Actualizar el feed de la UI (este ejemplo simplemente cambia el color de la imagen como un placeholder)
            cameraFeedUI.color = Random.ColorHSV();  // Puedes reemplazarlo por una textura real m�s tarde
        }
    }
}
