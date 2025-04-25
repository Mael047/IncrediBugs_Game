using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscenasUI : MonoBehaviour
{
    public static TransicionEscenasUI Instance;

    [Header("Disolver")]
    public CanvasGroup disolverCanvasGroup;
    public float tiempoDisolverEntrada;
    public float tiempoDisolverSalida;

    [Header("Bloque")]
    public RectTransform bloqueObject;
    public float tiempoBloqueEntrada;
    public float tiempoBloqueSalida;
    public LeanTweenType bloqueEaseEntrada;
    public LeanTweenType bloqueEaseSalida;
    public float posicionFinalEntrada;
    public float posicionInicialSalida;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Inicia la disoluci�n al inicio
        //DisolverEntrada();
        BloqueEntrada();
    }
    private void DisolverEntrada()
    {
        LeanTween.alphaCanvas(disolverCanvasGroup, 0f, tiempoDisolverEntrada).setOnComplete(() =>
        {
            disolverCanvasGroup.blocksRaycasts = false; // Desactiva la interacci�n con el canvas
            disolverCanvasGroup.interactable = false; // Desactiva la interacci�n con el canvas
        });
    }

    public void DisolverSalida(int indexEscena)
    {
        disolverCanvasGroup.blocksRaycasts = true; // Activa la interacci�n con el canvas
        disolverCanvasGroup.interactable = true; // Activa la interacci�n con el canvas

        LeanTween.alphaCanvas(disolverCanvasGroup, 1f, tiempoDisolverSalida).setOnComplete(() =>
        {
            SceneManager.LoadScene(indexEscena);
        });

    }

    private void BloqueEntrada()
    {
        LeanTween.moveX(bloqueObject, posicionFinalEntrada, tiempoBloqueEntrada).setEase(bloqueEaseEntrada)
            .setOnComplete(() =>
            {
                bloqueObject.gameObject.SetActive(false); // Desactiva el objeto despu�s de la animaci�n
            });
    }
    public void BloqueSalida(int indexEscena)
    {
        bloqueObject.anchoredPosition = new Vector2(posicionInicialSalida, 0f);
        // Establece la posici�n inicial
        bloqueObject.gameObject.SetActive(true); // Activa el objeto antes de la animaci�n  

        LeanTween.moveX(bloqueObject, 0f, tiempoBloqueSalida).setEase(bloqueEaseSalida).setOnComplete(() =>
        {
           SceneManager.LoadScene(indexEscena);
        });
    }

    public void BloqueSalida(string nombreEscena)
    {
        bloqueObject.anchoredPosition = new Vector2(posicionInicialSalida, 0f);
        // Establece la posici�n inicial
        bloqueObject.gameObject.SetActive(true); // Activa el objeto antes de la animaci�n  

        LeanTween.moveX(bloqueObject, 0f, tiempoBloqueSalida).setEase(bloqueEaseSalida).setOnComplete(() =>
        {
            SceneManager.LoadScene(nombreEscena);
        });
    }

}

