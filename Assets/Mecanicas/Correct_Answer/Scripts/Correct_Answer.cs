using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UIElements;
using TMPro.Examples;

public class Correct_Answer : MonoBehaviour
{

    public Animator animator;

    [SerializeField] private Canvas canvasActual;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Respuesta Correcta")]
    public string RespuestaCorrecta;

    [Header("Respuesta de este botón")]
    public string Respuesta;

    [Header("Proximo Canvas")]
    public Canvas ProximoCanvas;

    [Header("Caracter")]
    public GameObject Caracter;

    [Header("Indicar la seccion del nivel")] // Ingles - Matematica - Geografia - Musica
    public string SeccionNivel;

    [Header("Cambio de Escena?")]
    public string CambioEscena;

    int puntos = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Solo es necesario indicar el canvas y los puntos maximos en el boton que sea la respuesta correcta 
    public void CheckAnswer()
    {
        
        if (Respuesta == RespuestaCorrecta)
        {
            Debug.Log("Respuesta Correcta");
            puntos += 1;
            if (CambioEscena == "Si")
            {
                StartCoroutine(Second());
            }
            else if(CambioEscena == "No")
            {
                CambiarCanvas();
                Debug.Log("Puntos" + puntos);
            }
        }
        else
        {
            Debug.Log("Respuesta Incorrecta");
        }
    }

    // Indicacion para el nuevo canvas en caso de nuevos niveles
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

}
