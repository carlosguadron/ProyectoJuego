using UnityEngine; // Importa la biblioteca de Unity para usar sus funciones y componentes.

public class PlayerMovement : MonoBehaviour
{
    // Variables publicas (se pueden modificar desde el Inspector en Unity)
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float rotationSpeed = 100f; // Velocidad de rotacion del personaje

    private Rigidbody rb; // Referencia al Rigidbody del jugador
    private Vector3 moveDirection; // Vector que almacena la direccion del movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody del objeto al que esta asignado este script
        rb.freezeRotation = true; // Evita que el Rigidbody rote debido a colisiones o fuerzas externas
    }

    void Update()
    {
        // Rotacion con teclas A y D
        float rotation = 0f;
        if (Input.GetKey(KeyCode.A)) // Si el jugador presiona "A", gira a la izquierda
        {
            rotation = -rotationSpeed * Time.deltaTime; // Gira en sentido contrario a las agujas del reloj
        }
        else if (Input.GetKey(KeyCode.D)) // Si el jugador presiona "D", gira a la derecha
        {
            rotation = rotationSpeed * Time.deltaTime; // Gira en el sentido de las agujas del reloj
        }
        transform.Rotate(0, rotation, 0); // Aplica la rotacion en el eje Y (vertical)

        // Definir direccion de movimiento con W y S
        moveDirection = Vector3.zero; // Inicializamos el vector en cero (sin movimiento)
        if (Input.GetKey(KeyCode.W)) // Si el jugador presiona "W", se mueve hacia adelante
        {
            moveDirection = transform.forward; // La direccion de movimiento es hacia adelante (en relacion con la rotacion del jugador)
        }
        else if (Input.GetKey(KeyCode.S)) // Si el jugador presiona "S", se mueve hacia atras
        {
            moveDirection = -transform.forward; // La direccion de movimiento es hacia atras
        }
    }

    void FixedUpdate()
    {
        // Aplicar la velocidad en la direccion seleccionada
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        // Usamos rb.velocity para modificar la velocidad directamente en lugar de agregar fuerza.
        // Se mantiene rb.velocity.y para que la gravedad siga afectando al personaje.
    }
}
