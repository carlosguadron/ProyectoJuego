using UnityEngine;

public class ZombieVision : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float fieldOfView = 180f; // Campo de visión del zombi en grados
    public float viewDistance = 10f; // Distancia máxima en la que el zombi puede ver
    public float moveSpeed = 2f; // Velocidad del zombi al seguir al jugador

    public ZombieEyeUI eyeUI; // Referencia al script del icono del ojo

    private bool playerInSight = false; // Variable para detectar si el jugador está en visión

    void Update()
    {
        Vector3 zombieForward = transform.forward.normalized;
        Vector3 toPlayer = (player.position - transform.position);
        float distanceToPlayer = toPlayer.magnitude;
        toPlayer.Normalize();

        // Si el jugador está fuera del rango de visión, el zombi no lo ve
        if (distanceToPlayer > viewDistance)
        {
            SetPlayerInSight(false);
            return;
        }

        // Calculamos el ángulo entre la dirección del zombi y el jugador
        float dotProduct = Vector3.Dot(zombieForward, toPlayer);
        float angleToPlayer = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        // Si el jugador está dentro del campo de visión, el zombi lo ve
        if (angleToPlayer < fieldOfView / 2)
        {
            SetPlayerInSight(true);
            FollowPlayer();
        }
        else
        {
            SetPlayerInSight(false);
        }
    }

    void SetPlayerInSight(bool isVisible)
    {
        if (playerInSight != isVisible)
        {
            playerInSight = isVisible;
            if (playerInSight)
            {
                eyeUI.ShowEye(); // Muestra el icono sobre el zombi
            }
            else
            {
                eyeUI.HideEye(); // Oculta el icono
            }
        }
    }

    void FollowPlayer()
    {
        // Mueve al zombi en dirección al jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
