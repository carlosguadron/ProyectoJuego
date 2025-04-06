using UnityEngine;

public class AmongUsFPSMovement : MonoBehaviour
{
    [Header("Configuración del Crewmate")]
    public float velocidadCaminar = 5f;       // Velocidad base del crewmate
    public float velocidadCorrer = 8f;        // Velocidad al hacer tareas rápidas
    public float sensibilidadMouse = 100f;    // Sensibilidad de la mira
    public float gravedad = -9.81f;           // Gravedad del mapa

    [Header("Referencias")]
    public Transform camaraCrewmate;          // Arrastra la cámara aquí
    public CharacterController controlador;   // Arrastra el CharacterController

    private float rotacionX = 0f;
    private Vector3 velocidadVertical;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el ratón en el juego
    }

    void Update()
    {
        MoverCrewmate();
        RotarCamaraConMouse();
    }

    void MoverCrewmate()
    {
        // Input WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * horizontal + transform.forward * vertical;
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadCaminar;

        controlador.Move(direccion * velocidadActual * Time.deltaTime);

        // Gravedad
        if (controlador.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }
        velocidadVertical.y += gravedad * Time.deltaTime;
        controlador.Move(velocidadVertical * Time.deltaTime);
    }

    void RotarCamaraConMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        // Rotación vertical (evita voltear al revés)
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        camaraCrewmate.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        // Rotación horizontal
        transform.Rotate(Vector3.up * mouseX);
    }
}