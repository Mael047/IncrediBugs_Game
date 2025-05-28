using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class Pantalla_Felicitacion : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Caracter")]
    public GameObject Character;
    public Animator animator;

    [SerializeField] private AudioClip sonidoAcabar;

    [Header("Indicar la seccion del nivel")] // Ingles - Matematica - Geografia - Musica
    public string SeccionNivel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        Character.SetActive(true);
        animator.SetFloat("Felicitacion", 1);
        Debug.Log("Animacion completada");
        ControladorSonido.Instance.EjecutarSonido(sonidoAcabar);
        yield return new WaitForSeconds(2f);
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
        Debug.Log("Cargando nivel");
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
