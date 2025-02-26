using UnityEngine;

public class FixedUpdateRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Velocidad de rotacion

    private bool rotateX = false; // Variable para detectar la tecla

    void Update()
    {
        // Detectar si la tecla A est� presionada (se detecta en Update)
        rotateX = Input.GetKey(KeyCode.A);
    }

    void FixedUpdate()
    {
        // Aplicar rotaci�n en X en FixedUpdate si la tecla A est� presionada
        if (rotateX)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
