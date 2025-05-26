using UnityEngine;

// Controlador avanzado para luces con tres modos: encendido/apagado, rotaci�n y flash
public class LuzControlador : MonoBehaviour
{
    // Grupo de luces que se controlar� actualmente
    public enum Grupo { Delanteras, Medias, Traseras }
    public Grupo grupoActual;

    // Ajustes de rotaci�n
    public float velocidadRotacion = 100f;  // Velocidad de rotaci�n en grados/segundo
    public float anguloMaximo = 50f;       // �ngulo m�ximo de rotaci�n en grados

    // Arrays para guardar estados iniciales
    private Light[] luces;                 // Todas las luces hijas
    private float[] intensidadesOriginales; // Intensidad original de cada luz
    private float[] angulosActuales;        // �ngulo actual de cada luz
    private bool[] direccionesSubiendo;     // Direcci�n de rotaci�n de cada luz

    // Estados del sistema
    private bool lucesEncendidas = true;    // Si las luces est�n activadas
    private bool rotando = false;           // Si la rotaci�n est� activa
    private bool flashing = false;          // Si el efecto flash est� activo

    // Ajustes del efecto flash
    public float flashSpeed = 5f;           // Velocidad del efecto flash
    public float flashIntensityMin = 0.5f;  // Intensidad m�nima durante el flash
    public float flashIntensityMax = 5f;    // Intensidad m�xima durante el flash

    // Inicializaci�n: obtiene referencias y guarda estados iniciales
    void Start()
    {
        // Busca todas las luces hijas del objeto
        luces = GetComponentsInChildren<Light>();

        // Inicializa los arrays de estado
        intensidadesOriginales = new float[luces.Length];
        angulosActuales = new float[luces.Length];
        direccionesSubiendo = new bool[luces.Length];

        // Guarda los valores iniciales de cada luz
        for (int i = 0; i < luces.Length; i++)
        {
            intensidadesOriginales[i] = luces[i].intensity;  // Guarda intensidad original
            angulosActuales[i] = 0f;                         // Inicia �ngulo en 0
            direccionesSubiendo[i] = true;                   // Empieza rotando hacia arriba
        }
    }

    // Actualizaci�n por frame - control principal
    void Update()
    {
        // Control por grupo seg�n tecla presionada
        switch (grupoActual)
        {
            case Grupo.Delanteras:
                if (Input.GetKeyDown(KeyCode.Keypad7)) ToggleLuces();    // 7: Toggle encendido
                if (Input.GetKeyDown(KeyCode.Keypad4)) ToggleRotacion(); // 4: Toggle rotaci�n
                if (Input.GetKeyDown(KeyCode.Keypad1)) ToggleFlash();    // 1: Toggle flash
                break;
            case Grupo.Medias:
                if (Input.GetKeyDown(KeyCode.Keypad8)) ToggleLuces();    // 8: Toggle encendido
                if (Input.GetKeyDown(KeyCode.Keypad5)) ToggleRotacion(); // 5: Toggle rotaci�n
                if (Input.GetKeyDown(KeyCode.Keypad2)) ToggleFlash();    // 2: Toggle flash
                break;
            case Grupo.Traseras:
                if (Input.GetKeyDown(KeyCode.Keypad9)) ToggleLuces();    // 9: Toggle encendido
                if (Input.GetKeyDown(KeyCode.Keypad6)) ToggleRotacion(); // 6: Toggle rotaci�n
                if (Input.GetKeyDown(KeyCode.Keypad3)) ToggleFlash();    // 3: Toggle flash
                break;
        }

        // Si la rotaci�n est� activa, actualiza posici�n de luces
        if (rotando)
        {
            for (int i = 0; i < luces.Length; i++)
            {
                // Calcula direcci�n (1 para subir, -1 para bajar)
                float direccion = direccionesSubiendo[i] ? 1f : -1f;
                // Calcula rotaci�n basada en velocidad y tiempo
                float rotacion = velocidadRotacion * Time.deltaTime * direccion;

                // Aplica rotaci�n a la luz
                luces[i].transform.Rotate(Vector3.right * rotacion, Space.Self);
                angulosActuales[i] += rotacion;

                // Si supera el �ngulo m�ximo, cambia direcci�n
                if (Mathf.Abs(angulosActuales[i]) >= anguloMaximo)
                {
                    direccionesSubiendo[i] = !direccionesSubiendo[i];
                    angulosActuales[i] = Mathf.Clamp(angulosActuales[i], -anguloMaximo, anguloMaximo);
                }
            }
        }

        // Si el flash est� activo, actualiza intensidad de luces
        if (flashing)
        {
            // Calcula intensidad con efecto ping-pong entre min y max
            float intensidadActual = Mathf.PingPong(Time.time * flashSpeed, flashIntensityMax - flashIntensityMin) + flashIntensityMin;
            // Aplica a todas las luces
            foreach (var luz in luces)
                luz.intensity = intensidadActual;
        }
    }

    // Alterna el estado encendido/apagado de todas las luces
    void ToggleLuces()
    {
        lucesEncendidas = !lucesEncendidas;
        foreach (var luz in luces)
            luz.enabled = lucesEncendidas;
    }

    // Alterna el estado de rotaci�n
    void ToggleRotacion()
    {
        rotando = !rotando;
    }

    // Alterna el efecto flash y restaura intensidad original al desactivar
    void ToggleFlash()
    {
        flashing = !flashing;

        // Al desactivar flash, restaura intensidades originales
        if (!flashing)
        {
            for (int i = 0; i < luces.Length; i++)
                luces[i].intensity = intensidadesOriginales[i];
        }
    }
}