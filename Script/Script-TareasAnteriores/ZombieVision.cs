using UnityEngine; // Importa la biblioteca de Unity para usar sus funciones y componentes.

public class ZombieVision : MonoBehaviour
{
    // Variables públicas (se pueden modificar desde el Inspector en Unity)
    public Transform player; // Referencia al jugador para conocer su posición.
    public float fieldOfView = 180f; // Campo de visión del zombi en grados (180° significa que ve todo al frente).
    public float viewDistance = 10f; // Distancia máxima a la que el zombi puede ver al jugador.
    public float moveSpeed = 2f; // Velocidad con la que el zombi sigue al jugador.

    public ZombieEyeUI eyeUI; // Referencia al script que controla el icono del ojo en la cabeza del zombi.

    // Variable privada para saber si el jugador está dentro del campo de visión del zombi
    private bool playerInSight = false;

    void Update()
    {
        // Obtiene la dirección hacia la que está mirando el zombi (vector normalizado)
        Vector3 zombieForward = transform.forward.normalized;

        // Calcula el vector desde el zombi hacia el jugador
        Vector3 toPlayer = (player.position - transform.position);

        // Calcula la distancia entre el zombi y el jugador
        float distanceToPlayer = toPlayer.magnitude;

        // Normaliza el vector para que solo represente la dirección sin importar la distancia
        toPlayer.Normalize();

        // Si el jugador está más lejos de la distancia de visión, el zombi no lo ve
        if (distanceToPlayer > viewDistance)
        {
            SetPlayerInSight(false); // Oculta el icono del ojo y deja de seguir al jugador
            return; // Sale de la función para no seguir calculando
        }

        // Calcula el producto punto entre la dirección del zombi y el vector hacia el jugador
        float dotProduct = Vector3.Dot(zombieForward, toPlayer);

        // Convierte el resultado del producto punto en un ángulo en grados
        float angleToPlayer = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        // Si el ángulo entre el zombi y el jugador es menor que la mitad del campo de visión, lo ve
        if (angleToPlayer < fieldOfView / 2)
        {
            SetPlayerInSight(true); // Activa el icono del ojo y comienza a seguir al jugador
            FollowPlayer(); // Llama a la función para que el zombi se mueva hacia el jugador
        }
        else
        {
            SetPlayerInSight(false); // Si el jugador está fuera del campo de visión, oculta el icono
        }
    }

    // Función para actualizar si el jugador está en la visión del zombi o no
    void SetPlayerInSight(bool isVisible)
    {
        // Solo cambia el estado si realmente ha cambiado (evita llamadas innecesarias)
        if (playerInSight != isVisible)
        {
            playerInSight = isVisible;
            if (playerInSight)
            {
                eyeUI.ShowEye(); // Muestra el icono del ojo sobre el zombi
            }
            else
            {
                eyeUI.HideEye(); // Oculta el icono del ojo cuando el jugador sale del campo de visión
            }
        }
    }

    // Función que mueve al zombi hacia la posición del jugador
    void FollowPlayer()
    {
        // Mueve al zombi en dirección al jugador con una velocidad constante
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
    if (player == null) return; // Evita errores si el jugador no está asignado

        // Color del área de visión
        Gizmos.color = Color.green;

        // Dibuja una esfera indicando la distancia de visión del zombi
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        // Dibuja las líneas que representan el campo de visión
        Vector3 leftLimit = Quaternion.Euler(0, -fieldOfView / 2, 0) * transform.forward;
        Vector3 rightLimit = Quaternion.Euler(0, fieldOfView / 2, 0) * transform.forward;

        Gizmos.color = Color.red; // Cambia el color de las líneas del FOV
        Gizmos.DrawLine(transform.position, transform.position + leftLimit * viewDistance);
        Gizmos.DrawLine(transform.position, transform.position + rightLimit * viewDistance);
    }
}
