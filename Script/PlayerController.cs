using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float rotationSpeed = 100f; // Velocidad de rotaci�n

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que el personaje gire incontroladamente por la f�sica
    }

    void Update()
    {
        // Rotaci�n con A y D
        float rotation = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }
        transform.Rotate(0, rotation, 0);

        // Definir direcci�n de movimiento con W y S
        moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = transform.forward; // Mover hacia adelante
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -transform.forward; // Mover hacia atr�s
        }
    }

    void FixedUpdate()
    {
        // Aplicar la velocidad en la direcci�n seleccionada
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }
}

