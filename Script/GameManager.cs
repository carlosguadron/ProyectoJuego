using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject jugador;
    public GameObject panelMenuPrincipal;
    public GameObject panelPausa;
    public GameObject panelConfiguracion;
    public static GameManager Instance { get; private set; }


    [Header("Configuración de Volumen")]
    public Slider sliderVolumen;

    private bool configDesdePausa = false;

    private void Start()
    {
        MostrarMenuPrincipal(true);

        if (sliderVolumen != null)
        {
            float volumenGuardado = PlayerPrefs.GetFloat("volumen", 0.5f);
            sliderVolumen.value = volumenGuardado;
            CambiarVolumen(volumenGuardado);
            sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelConfiguracion.activeSelf)
            {
                VolverDesdeConfiguracion();
            }
            else if (panelPausa.activeSelf)
            {
                MostrarMenuPausa(false);
            }
            else if (!panelMenuPrincipal.activeSelf)
            {
                MostrarMenuPausa(true);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntaje actual: " + score);
    }


    public void CambiarVolumen(float nuevoVolumen)
    {
        if (MusicaFondo.instancia != null)
            MusicaFondo.instancia.CambiarVolumen(nuevoVolumen);
    }

    public void IniciarJuego()
    {
        panelMenuPrincipal.SetActive(false);
        panelPausa.SetActive(false);
        panelConfiguracion.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ActivarJugadorYJugar();
    }

    public void ActivarJugadorYJugar()
    {
        jugador.GetComponent<PlayerControllerRaminguin>().enabled = true;
        jugador.GetComponent<PlayerControllerRaminguin>().BloquearMovimiento(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MostrarMenuPrincipal(bool mostrar)
    {
        panelMenuPrincipal.SetActive(mostrar);

        panelPausa.SetActive(false);
        panelConfiguracion.SetActive(false);

        jugador.GetComponent<PlayerControllerRaminguin>().enabled = !mostrar;
        Time.timeScale = mostrar ? 0f : 1f;

        Cursor.lockState = mostrar ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = mostrar;
    }

    public void MostrarMenuPausa(bool mostrar)
    {
        panelPausa.SetActive(mostrar);
        jugador.GetComponent<PlayerControllerRaminguin>().BloquearMovimiento(mostrar);
        jugador.GetComponent<PlayerControllerRaminguin>().enabled = !mostrar;

        Time.timeScale = mostrar ? 0f : 1f;

        Cursor.lockState = mostrar ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = mostrar;
    }

    public void AbrirConfiguracionDesdePausa()
    {
        configDesdePausa = true;
        panelPausa.SetActive(false);
        panelConfiguracion.SetActive(true);
    }

    public void AbrirConfiguracionDesdePrincipal()
    {
        configDesdePausa = false;
        panelMenuPrincipal.SetActive(false);
        panelConfiguracion.SetActive(true);
    }

    public void VolverDesdeConfiguracion()
    {
        panelConfiguracion.SetActive(false);

        if (configDesdePausa)
        {
            panelPausa.SetActive(true);
        }
        else
        {
            panelMenuPrincipal.SetActive(true);
        }
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void EndTurn()
    {
        Debug.Log("Turno terminado");
        // Aquí pones lo que deba pasar cuando termina el turno
    }

}
