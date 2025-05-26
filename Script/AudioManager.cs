using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicaSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Cargar volúmenes guardados
            musicaSource.volume = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);
            sfxSource.volume = PlayerPrefs.GetFloat("VolumenSFX", 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolumenMusica(float valor)
    {
        musicaSource.volume = valor;
        PlayerPrefs.SetFloat("VolumenMusica", valor);
    }

    public void SetVolumenSFX(float valor)
    {
        sfxSource.volume = valor;
        PlayerPrefs.SetFloat("VolumenSFX", valor);
    }

    public void ReproducirSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
