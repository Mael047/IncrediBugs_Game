using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro.Examples;

public class Correct_Answer : MonoBehaviour
{

    public Animator animator;
 
    [Header("Respuesta Correcta")]
    public string RespuestaCorrecta;

    [Header("Respuesta de este botón")]
    public string Respuesta;

    [Header("Puntos maximos")]
    public int PuntosMaximos;

    [Header("Canvas Actual")]
    public Canvas canvasActual;

    [Header("Proximo Canvas")]
    public Canvas ProximoCanvas;

    [Header("Caracter")]
    public GameObject Caracter;

    [Header("Nivel al que va despues de ganar")]
    public int Nivel;

    int puntos = 0;


    // Solo es necesario indicar el canvas y los puntos maximos en el boton que sea la respuesta correcta 
    public void CheckAnswer()
    {
        
        if (Respuesta == RespuestaCorrecta)
        {
            Debug.Log("Respuesta Correcta");
            puntos += 1;
            Debug.Log("Puntos" + puntos);
            if (puntos == PuntosMaximos)
            {
                CambiarCanvas();
                animator.SetFloat("Felicitacion",1);
                StartCoroutine(Second());
                Debug.Log("Has ganado");
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
        yield return new WaitForSeconds(5f);
        TransicionEscenasUI.Instance.BloqueSalida(Nivel);
    }

}
