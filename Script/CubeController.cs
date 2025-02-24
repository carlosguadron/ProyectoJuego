using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float rotationSpeed = 50f; // Velocidad de rotaci�n



    private void Update()
    {
        /* 
         
             // Movimiento constante hacia adelante en cada frame
             transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

             // Rotaci�n en Update (afectada por los FPS)
             transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        */

        if (Input.GetKey(KeyCode.R)) // Si presionas R, rota
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }


    }

    private void FixedUpdate()
    {
        // Rotaci�n en FixedUpdate (m�s consistente con la f�sica)
        transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime);
    }
}
