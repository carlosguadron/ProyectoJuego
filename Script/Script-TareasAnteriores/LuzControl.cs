using UnityEngine;

// Controlador avanzado para luces con tres modos: encendido/apagado, rotación y flash
public class LuzControlador : MonoBehaviour
{
    // Grupo de luces que se controlará actualmente
    public enum Grupo { Delanteras, Medias, Traseras }
    public Grupo grupoActual;

    // Ajustes de rotación
    public float velocidadRotacion = 100f;  // Velocidad de rotación en grados/segundo
    public float anguloMaximo = 50f;       // Ángulo máximo de rotación en grados

    // Arrays para guardar estados iniciales
    private Light[] luces;                 // Todas las luces hijas
    private float[] intensidadesOriginales; // Intensidad original de cada luz
    private float[] angulosActuales;        // Ángulo actual de cada luz
    private bool[] direccionesSubiendo;     // Dirección de rotación de cada luz

    // Estados del sistema
    private bool lucesEncendidas = true;    // Si las luces están activadas
    private bool rotando = false;           // Si la rotación está activa
    private bool flashing = false;          // Si el efecto flash está activo

    // Ajustes del efecto flash
    public float flashSpeed = 5f;           // Velocidad del efecto flash
    public float flashIntensityMin = 0.5f;  // Intensidad mínima durante el flash
    public float flashIntensityMax = 5f;    // Intensidad máxima durante el flash

    // Inicialización: obtiene referencias y guarda estados iniciales
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
            angulosActuales[i] = 0f;                         // Inicia ángulo en 0
            direccionesSubiendo[i] = true;                   // Empieza rotando hacia arriba
        }
    }

    // Actualización por frame - control principal
    void Update()
    {
        // Control por grupo según tecla presionada
        switch (grupoActual)
        {
            case Grupo.Delanteras:
                if (Input.GetKeyDown(KeyCode.Keypad7)) ToggleLuces();    // 7: Toggle encendido
                if (Input.GetKeyDown(KeyCode.Keypad4)) ToggleRotacion(); // 4: Toggle rotación
                if (Input.GetKeyDown(KeyCode.Keypad1)) ToggleFlash();    // 1: Toggle flash
                break;
            case Grupo.Medias:
                if (Input.GetKeyDown(KeyCode.Keypad8)) ToggleLuces();    // 8: Toggle encendido
                if (Input.GetKeyDown(KeyCode.Keypad5)) ToggleRotacion(); // 5: Toggle rotación
                if (Input.GetKeyDown(KeyCode.Keypad2)) ToggleFlash();    // 2: Toggle flash
                break;
            case Grupo.Traseras:
                if (Input.GetKeyDown(KeyCode.Keypad9)) ToggleLuces();    // 9: Toggle encendido
                if (Input.GetKeyDown(KeyCode.Keypad6)) ToggleRotacion(); // 6: Toggle rotación
                if (Input.GetKeyDown(KeyCode.Keypad3)) ToggleFlash();    // 3: Toggle flash
                break;
        }

        // Si la rotación está activa, actualiza posición de luces
        if (rotando)
        {
            for (int i = 0; i < luces.Length; i++)
            {
                // Calcula dirección (1 para subir, -1 para bajar)
                float direccion = direccionesSubiendo[i] ? 1f : -1f;
                // Calcula rotación basada en velocidad y tiempo
                float rotacion = velocidadRotacion * Time.deltaTime * direccion;

                // Aplica rotación a la luz
                luces[i].transform.Rotate(Vector3.right * rotacion, Space.Self);
                angulosActuales[i] += rotacion;

                // Si supera el ángulo máximo, cambia dirección
                if (Mathf.Abs(angulosActuales[i]) >= anguloMaximo)
                {
                    direccionesSubiendo[i] = !direccionesSubiendo[i];
                    angulosActuales[i] = Mathf.Clamp(angulosActuales[i], -anguloMaximo, anguloMaximo);
                }
            }
        }

        // Si el flash está activo, actualiza intensidad de luces
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

    // Alterna el estado de rotación
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