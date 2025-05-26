using UnityEngine;

public class ActivarUICamaras : MonoBehaviour
{
    // Referencia al canvas del UI que contiene las camaras
    public GameObject canvasUICamaras;
    // Referencia al script MovimientoJugadorCamaraSeguridad para controlar el movimiento del jugador
    public MovimientoJugadorCamaraSeguridad movimientoJugador;

    // Variable que se activa cuando el jugador esta dentro de la zona
    private bool jugadorDentro = false;


    void Update()
    {
        // Si el jugador esta dentro del trigger y presiona la tecla C
        if (jugadorDentro && Input.GetKeyDown(KeyCode.C))
        {
            // Se alterna la visibilidad del UI de camaras
            bool mostrarUI = !canvasUICamaras.activeSelf;
            canvasUICamaras.SetActive(mostrarUI);

            // Si el UI se esta mostrando, el jugador no puede moverse
            if (movimientoJugador != null)
                movimientoJugador.puedeMoverse = !mostrarUI;
        }
    }

    // Se ejecuta cuando un objeto entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra es el jugador (con la etiqueta "Player")
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    // Se ejecuta cuando un objeto sale del trigger
    void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
            // Desactiva el UI de camaras al salir
            canvasUICamaras.SetActive(false);

            // Si el jugador sale, puede moverse nuevamente
            if (movimientoJugador != null)
                movimientoJugador.puedeMoverse = true;
        }
    }
}
