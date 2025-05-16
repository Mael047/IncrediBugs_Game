using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Points_Flags : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Indicar la seccion del nivel")] // Ingles - Matematica - Geografia - Musica
    public string SeccionNivel;

    [Header("Caracter")]
    public GameObject Caracter;

    [Header("Canvas Actual")]
    public Canvas CanvasActual;

    [Header("Proximo Canvas")]
    public Canvas ProximoCanvas;

    private int Points = 0;
    private int MaxPoints = 0;
    private int MaxPointsItem = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        Points = 0;
        MaxPoints = GameObject.FindGameObjectsWithTag("Slot").Length;
        MaxPointsItem = GameObject.FindGameObjectsWithTag("Animal").Length;

        Debug.Log(MaxPoints);
        Debug.Log(MaxPointsItem + "cantidad de animales");
    }

    public void AddPoint()
    {
        Points++;
        Debug.Log(Points);  
        if (Points == MaxPoints)
        {
            StartCoroutine(Second());
        }
    }

    public void HorsePoint()
    {
        Points++;
        StartCoroutine(Canvas_Change());
        if (Points == 2)
        {
            StartCoroutine(Second());
        }
    }

    IEnumerator Second()
    {
        animator.SetFloat("Felicitacion", 1);
        yield return new WaitForSeconds(3f);
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
        Debug.Log("Cambiar Canvas" + SeccionNivel);
        if (SeccionNivel == "Ingles")
        {
            TransicionEscenasUI.Instance.BloqueSalida("Menu_Ingles");
        }
        else if (SeccionNivel == "Matematica")
        {
            TransicionEscenasUI.Instance.BloqueSalida("Menu_Math");
        }
        else if (SeccionNivel == "Geografia")
        {
            TransicionEscenasUI.Instance.BloqueSalida("Menu_Geografia");
        }
        else if (SeccionNivel == "Musica")
        {
            TransicionEscenasUI.Instance.BloqueSalida("Menu_Musica");
        }
    }

    IEnumerator Canvas_Change()
    {
        yield return new WaitForSeconds(3f);

        if (CanvasActual != null)
            CanvasActual.gameObject.SetActive(false);

        if (ProximoCanvas != null)
            ProximoCanvas.gameObject.SetActive(true);

    }
}
