using UnityEngine;

public class ActivarCamarasAlInicio : MonoBehaviour
{
    // Se crea un array publico de GameObjects para almacenar las camaras.
    public GameObject[] camaras;

    // Start se ejecuta al inicio del juego
    void Start()
    {
        // Recorremos todas las camaras en el array
        foreach (GameObject camara in camaras)
        {
            // Activamos cada camara en el array
            camara.SetActive(true);
        }
    }
}
