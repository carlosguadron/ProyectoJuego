using UnityEngine;

public class RotateOnKey : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación
    private bool rotateX = false; // Variable para detectar la tecla E

    void Update()
    {
        // Rotación en el eje Y con la tecla R (en Update, dependiente de FPS)
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Detectar si la tecla E está presionada para activar la rotación en FixedUpdate
        rotateX = Input.GetKey(KeyCode.E);
    }

    void FixedUpdate()
    {
        // Rotación en el eje X con la tecla E (en FixedUpdate, más estable para física)
        
            transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        
    }
}
