using UnityEngine;

public class AgarrarYLevantar : MonoBehaviour
{
    public Transform pointOfAttachment; // Punto donde se "agarrará" el objeto
    public float distanceToObject = 3f; // Distancia a la que puedes agarrar el objeto
    public float objectLiftSpeed = 5f; // Velocidad con la que el objeto se mueve con el jugador
    public KeyCode grabKey = KeyCode.Mouse0; // Tecla para agarrar (clic izquierdo por defecto)
    public KeyCode releaseKey = KeyCode.Mouse1; // Tecla para soltar (clic derecho por defecto)

    private Camera playerCamera; // Cámara del jugador
    private Transform objectToHold; // Objeto que estás agarrando
    private bool isHoldingObject = false; // Si estás sosteniendo un objeto
    private Rigidbody objectRigidbody; // El Rigidbody del objeto
    private bool canMove = true; // Si puedes mover el jugador normalmente

    private void Start()
    {
        playerCamera = Camera.main; // Asume que la cámara principal es la del jugador
    }

    void Update()
    {
        if (!isHoldingObject)
        {
            MoverJugador(); // Llama al movimiento del jugador solo si no está sosteniendo el objeto.
        }

        if (isHoldingObject)
        {
            MoverObjetoConJugador(); // Lógica para mover el objeto con el jugador
        }

        if (Input.GetKeyDown(grabKey))
        {
            AgarrarObjeto();
        }

        if (Input.GetKeyDown(releaseKey))
        {
            SoltarObjeto();
        }
    }

    void MoverJugador()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * Time.deltaTime * 5f; // Movimiento simple
        transform.Translate(movement, Space.Self); // Mover al jugador
    }

    void AgarrarObjeto()
    {
        // Raycast hacia adelante desde la cámara del jugador
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, distanceToObject))
        {
            if (hit.collider.CompareTag("Agarrable")) // Ahora se usa el tag "Agarrable"
            {
                objectToHold = hit.collider.transform; // Guardar el objeto que se ha tocado
                objectRigidbody = objectToHold.GetComponent<Rigidbody>();

                // Hacer que el objeto deje de ser afectado por la física temporalmente
                objectRigidbody.isKinematic = true;

                // Configurar el objeto para que se mueva con el punto de sujeción
                objectToHold.SetParent(pointOfAttachment);
                objectToHold.localPosition = Vector3.zero; // Asegurarse de que se coloca bien
                objectToHold.localRotation = Quaternion.identity; // Resetear la rotación

                isHoldingObject = true; // Marcar que estás sosteniendo el objeto
                canMove = false; // Desactivar el movimiento del jugador mientras lo agarras
            }
        }
    }

    void SoltarObjeto()
    {
        if (isHoldingObject)
        {
            objectToHold.SetParent(null); // Desasociar el objeto del punto de sujeción

            // Reactivar la física del objeto
            objectRigidbody.isKinematic = false;

            isHoldingObject = false; // Dejar de sostener el objeto
            canMove = true; // Volver a activar el movimiento del jugador
        }
    }

    void MoverObjetoConJugador()
    {
        // Mueve el objeto hacia el jugador
        if (objectToHold != null)
        {
            // El objeto sigue al jugador
            objectToHold.position = Vector3.Lerp(objectToHold.position, pointOfAttachment.position, objectLiftSpeed * Time.deltaTime);
            objectToHold.rotation = Quaternion.Lerp(objectToHold.rotation, pointOfAttachment.rotation, objectLiftSpeed * Time.deltaTime);
        }
    }
}
