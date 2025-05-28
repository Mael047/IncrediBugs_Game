using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;

public class Correct_Answer : MonoBehaviour
{
    public Animator animator;

    [Header("Caracter")]
    public GameObject Caracter;

    [SerializeField] private Canvas canvasActual;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Proximo Canvas")]
    public Canvas ProximoCanvas;

    [Header("Indicar la seccion del nivel")] // Ingles - Matematica - Geografia - Musica
    public string SeccionNivel;

    [Header("Cambio de Escena?")]
    public string CambioEscena;

    [Header("Boton correcto")]
    public Button botonCorrecto;

    [SerializeField] private AudioClip sonidoCorrecto;
    [SerializeField] private AudioClip sonidoIncorrecto;
    [SerializeField] private AudioClip sonidoAcabar;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <param name="botonPresionado">Botón que se ha presionado</param>
    public void CheckAnswer(Button botonPresionado)
    {
        if (botonPresionado == botonCorrecto)
        {
            Debug.Log("Respuesta Correcta");
            ControladorSonido.Instance.EjecutarSonido(sonidoCorrecto);
            if (CambioEscena == "Si")
            {
                canvasGroup.blocksRaycasts = false;
                StartCoroutine(Second());
            }
            else if (CambioEscena == "No")
            {
                CambiarCanvas();
                Debug.Log("Puntos");
            }
        }
        else
        {
            ControladorSonido.Instance.EjecutarSonido(sonidoIncorrecto);
            Debug.Log("Respuesta Incorrecta");
        }
    }

    private void CambiarCanvas()
    {
        if (canvasActual != null)
            canvasActual.gameObject.SetActive(false);

        if (ProximoCanvas != null)
            ProximoCanvas.gameObject.SetActive(true);
    }

    IEnumerator Second()
    {
        animator.SetFloat("Felicitacion", 1);
        yield return new WaitForSeconds(3f);
        ControladorSonido.Instance.EjecutarSonido(sonidoAcabar);
        canvasGroup.alpha = 0.8f;
        yield return new WaitForSeconds(0.1f);
        canvasGroup.alpha = 0.5f;
        yield return new WaitForSeconds(0.1f);
        canvasGroup.alpha = 0.3f;
        yield return new WaitForSeconds(0.1f);
        canvasGroup.alpha = 0.1f;
        yield return new WaitForSeconds(0.1f);
        canvasGroup.alpha = 0f;
        yield return new WaitForSeconds(5f);

        switch (SeccionNivel)
        {
            case "Ingles":
                TransicionEscenasUI.Instance.BloqueSalida("Menu_Ingles");
                break;
            case "Matematica":
                TransicionEscenasUI.Instance.BloqueSalida("Menu_Math");
                break;
            case "Geografia":
                TransicionEscenasUI.Instance.BloqueSalida("Menu_Geografia");
                break;
            case "Musica":
                TransicionEscenasUI.Instance.BloqueSalida("Menu_Musica");
                break;
        }
    }
}
