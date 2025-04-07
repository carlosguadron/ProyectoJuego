using UnityEngine;

public class AmongUsBasicMovement : MonoBehaviour
{
    [Header("Velocidades")]
    public float velocidadNormal = 5f;
    public float velocidadSprint = 8f;
    public float sensibilidadMouse = 2f;
    public float velocidadRotacion = 10f;

    [Header("Referencias")]
    public Transform camara; // Cámara independiente

    private Rigidbody rb;
    private float rotacionX = 0f;
    private float mouseYRotacion = 0f;

    [Header("Límites de cámara")]
    public float limiteVertical = 80f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotarCamara();
        RotarPersonaje();
    }

    void FixedUpdate()
    {
        MoverJugador();
    }

    void RotarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        mouseYRotacion += mouseX;
        rotacionX -= mouseY;

        rotacionX = Mathf.Clamp(rotacionX, -limiteVertical, limiteVertical);

        camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, mouseYRotacion, 0f); // Rota solo en Y
    }

    void RotarPersonaje()
    {
        // El personaje rota suavemente hacia donde mira la cámara
        Vector3 objetivoDireccion = new Vector3(camara.forward.x, 0, camara.forward.z);
        if (objetivoDireccion != Vector3.zero)
        {
            Quaternion objetivoRotacion = Quaternion.LookRotation(objetivoDireccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, objetivoRotacion, Time.deltaTime * velocidadRotacion);
        }
    }

    void MoverJugador()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = camara.forward * vertical + camara.right * horizontal;
        direccion.y = 0f;
        direccion.Normalize();

        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadSprint : velocidadNormal;

        Vector3 velocidadActualY = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = direccion * velocidadActual + velocidadActualY;
    }
}
