using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    public static ControladorSonido Instance;

    private AudioSource musicaSource;
    private AudioSource efectosSource;

    [Range(0f, 1f)] public float volumenMusica = 0.1f;
    [Range(0f, 1f)] public float volumenEfectos = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            musicaSource = gameObject.AddComponent<AudioSource>();
            efectosSource = gameObject.AddComponent<AudioSource>();

            musicaSource.loop = true;
            musicaSource.volume = volumenMusica;

            efectosSource.loop = false;
            efectosSource.volume = volumenEfectos;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        if (efectosSource != null && sonido != null)
        {
            efectosSource.PlayOneShot(sonido);
        }
    }

    public void CambiarMusicaFondo(AudioClip nuevaMusica)
    {
        if (musicaSource != null && nuevaMusica != null)
        {
            musicaSource.clip = nuevaMusica;
            musicaSource.volume = volumenMusica; // en caso de que lo modifiques en runtime
            musicaSource.Play();
        }
    }

    public void CambiarVolumenMusica(float nuevoVolumen)
    {
        volumenMusica = nuevoVolumen;
        if (musicaSource != null) musicaSource.volume = nuevoVolumen;
    }

    public void CambiarVolumenEfectos(float nuevoVolumen)
    {
        volumenEfectos = nuevoVolumen;
        if (efectosSource != null) efectosSource.volume = nuevoVolumen;
    }
}
