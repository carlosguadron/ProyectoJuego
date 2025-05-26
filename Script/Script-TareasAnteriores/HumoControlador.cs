using UnityEngine;
using System.Linq;

/// <summary>
/// Controlador para manejar sistemas de partículas de humo en Unity.
/// Permite activar/desactivar grupos de humos usando teclas específicas.
/// Versión modificada para 8 humos (4 centrales y 4 exteriores)
/// </summary>
public class HumoControlador : MonoBehaviour
{
    // Estados de los humos
    private bool humosCentroActivos = false;
    private bool humosExterioresActivos = false;

    // Referencias a los sistemas de partículas
    private ParticleSystem[] humosCentro;
    private ParticleSystem[] humosCentroArriba;
    private ParticleSystem[] humosExteriores;
    private ParticleSystem[] humosExteriorArriba;

    void Start()
    {
        // Inicializar los arrays
        humosCentro = new ParticleSystem[2];
        humosCentroArriba = new ParticleSystem[2];
        humosExteriores = new ParticleSystem[2];
        humosExteriorArriba = new ParticleSystem[2];

        // Buscar y asignar cada humo por nombre
        AssignHumoByName("HumoCentro1", ref humosCentro, 0);
        AssignHumoByName("HumoCentro2", ref humosCentro, 1);
        AssignHumoByName("HumoCentroArriba1", ref humosCentroArriba, 0);
        AssignHumoByName("HumoCentroArriba2", ref humosCentroArriba, 1);
        AssignHumoByName("HumoExterior1", ref humosExteriores, 0);
        AssignHumoByName("HumoExterior2", ref humosExteriores, 1);
        AssignHumoByName("HumoExteriorArriba1", ref humosExteriorArriba, 0);
        AssignHumoByName("HumoExteriorArriba2", ref humosExteriorArriba, 1);

        // Configuración inicial
        ApagarTodosHumos();

        Debug.Log("Sistemas de humo inicializados correctamente");
    }

    void Update()
    {
        // Control con teclas
        if (Input.GetKeyDown(KeyCode.KeypadMinus))  // Tecla "-" para humos centrales
        {
            ToggleHumosCentro();
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus))  // Tecla "+" para humos exteriores
        {
            ToggleHumosExteriores();
        }
    }

    /// <summary>
    /// Asigna un humo específico a un array por nombre
    /// </summary>
    void AssignHumoByName(string name, ref ParticleSystem[] array, int index)
    {
        Transform humoTransform = transform.Find(name);
        if (humoTransform != null)
        {
            array[index] = humoTransform.GetComponent<ParticleSystem>();
            if (array[index] == null)
            {
                Debug.LogWarning($"El objeto {name} no tiene componente ParticleSystem");
            }
        }
        else
        {
            Debug.LogWarning($"No se encontró el objeto {name} en la jerarquía");
        }
    }

    void ToggleHumosCentro()
    {
        humosCentroActivos = !humosCentroActivos;

        // Controlar humos centrales normales
        foreach (var humo in humosCentro)
        {
            ToggleHumo(humo, humosCentroActivos);
        }

        // Controlar humos centrales de arriba
        foreach (var humo in humosCentroArriba)
        {
            ToggleHumo(humo, humosCentroActivos);
        }
    }

    void ToggleHumosExteriores()
    {
        humosExterioresActivos = !humosExterioresActivos;

        // Controlar humos exteriores normales
        foreach (var humo in humosExteriores)
        {
            ToggleHumo(humo, humosExterioresActivos);
        }

        // Controlar humos exteriores de arriba
        foreach (var humo in humosExteriorArriba)
        {
            ToggleHumo(humo, humosExterioresActivos);
        }
    }

    /// <summary>
    /// Controla un humo individual
    /// </summary>
    void ToggleHumo(ParticleSystem humo, bool activar)
    {
        if (humo != null)
        {
            if (activar)
                humo.Play();
            else
                humo.Stop();
        }
    }

    void ApagarTodosHumos()
    {
        // Apagar todos los sistemas de partículas hijos
        foreach (Transform child in transform)
        {
            ParticleSystem humo = child.GetComponent<ParticleSystem>();
            if (humo != null)
            {
                humo.Stop();
            }
        }

        // Restablecer estados
        humosCentroActivos = false;
        humosExterioresActivos = false;
    }
}