using UnityEngine;
using UnityEngine.UI;

public class OpcionesSonido : MonoBehaviour
{
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private Slider sliderEfectos;

    private void Start()
    {
        // Inicializa sliders con el volumen actual
        if (ControladorSonido.Instance != null)
        {
            sliderMusica.value = ControladorSonido.Instance.volumenMusica;
            sliderEfectos.value = ControladorSonido.Instance.volumenEfectos;
        }

        // Agrega listeners
        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderEfectos.onValueChanged.AddListener(CambiarVolumenEfectos);
    }

    private void CambiarVolumenMusica(float nuevoVolumen)
    {
        if (ControladorSonido.Instance != null)
        {
            ControladorSonido.Instance.CambiarVolumenMusica(nuevoVolumen);
        }
    }

    private void CambiarVolumenEfectos(float nuevoVolumen)
    {
        if (ControladorSonido.Instance != null)
        {
            ControladorSonido.Instance.CambiarVolumenEfectos(nuevoVolumen);
        }
    }
}
