using UnityEngine;

public class MovimientoJugadorCamaraSeguridad : MonoBehaviour
{
    // Velocidades de caminar y correr
    public float walkSpeed = 5f;
    public float runSpeed = 9f;
    // Sensibilidad del raton para mover la camara
    public float mouseSensitivity = 2f;

    // Referencia a la camara del jugador
    public Transform playerCamera;
    // Referencia al CharacterController para mover al jugador
    private CharacterController controller;
    // Rotacion en el eje X de la camara (para mirar arriba y abajo)
    float xRotation = 0f;
    // Variable booleana para controlar si el jugador puede moverse
    public bool puedeMoverse = true;

    // Start se ejecuta al inicio del juego
    void Start()
    {
        // Asegura que el jugador pueda moverse al inicio
        puedeMoverse = true;

        // Se obtiene la referencia al CharacterController del jugador
        controller = GetComponent<CharacterController>();

        // Bloquea el cursor en el centro de la pantalla y lo hace invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update se ejecuta una vez por frame
    void Update()
    {
        // Si el jugador puede moverse, ejecuta las funciones de movimiento y rotacion
        if (puedeMoverse)
        {
            MoverJugador();
            RotarCamara();
        }
    }

    // Controla el movimiento del jugador
    void MoverJugador()
    {
        // Si el jugador puede moverse
        if (puedeMoverse)
        {
            // Obtiene los valores de entrada de las teclas para movimiento (WASD)
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Calcula la direccion de movimiento
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            // Determina la velocidad de movimiento, segun si el jugador esta corriendo o caminando
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            // Mueve al jugador en la direccion calculada con la velocidad determinada
            controller.Move(move * speed * Time.deltaTime);
        }
    }

    // Controla la rotacion de la camara
    void RotarCamara()
    {
        // Obtiene la rotacion del raton en los ejes X (horizontal) y Y (vertical)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Actualiza la rotacion vertical de la camara (mira hacia arriba y hacia abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rota el cuerpo del jugador en el eje Y para moverlo horizontalmente
        transform.Rotate(Vector3.up * mouseX);
    }
}
