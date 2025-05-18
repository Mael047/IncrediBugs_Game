using UnityEngine;

public class CambiarMusicaAlEntrar : MonoBehaviour
{
    [SerializeField] private AudioClip musicaNivel;

    private void Start()
    {
        if (ControladorSonido.Instance != null && musicaNivel != null)
        {
            ControladorSonido.Instance.CambiarMusicaFondo(musicaNivel);
        }
    }
}
