using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Sumas_restas : MonoBehaviour
{
    [SerializeField] private TMP_Text numberText;
    [SerializeField] private TMP_Text numberText2;
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private AudioClip sonidoAcabar;

    private int correctAnswer;

    public Animator animator;
    [Header("Caracter")]
    public GameObject Caracter;

    [Header("Indicar la seccion del nivel")] // Ingles - Matematica - Geografia - Musica
    public string SeccionNivel;

    private int puntos = 0;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        StartCoroutine(DelayedGenerate());
    }

    public void GenerateNumbers()
    {
        int randomNumber1 = Random.Range(1, 10);
        int randomNumber2 = Random.Range(1, 10);

        bool isAddition = Random.Range(0, 2) == 0;

        if (isAddition)
        {
            numberText.text = randomNumber1.ToString();
            numberText2.text = " + " + randomNumber2.ToString() + " = ? ";
            correctAnswer = randomNumber1 + randomNumber2;
        }
        else
        {
            // Resta sin negativos
            int max = Mathf.Max(randomNumber1, randomNumber2);
            int min = Mathf.Min(randomNumber1, randomNumber2);

            numberText.text = max.ToString();
            numberText2.text = " - " + min.ToString() + " = ? " ;
            correctAnswer = max - min;
        }

        Debug.Log("Correct Answer: " + correctAnswer);

        int correctIndex = Random.Range(0, answerButtons.Length);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int answer;
            if (i == correctIndex)
            {
                answer = correctAnswer;
            }
            else
            {
                do
                {
                    answer = Random.Range(0, 20); // 0 incluido
                } while (answer == correctAnswer);
            }

            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = answer.ToString();

            answerButtons[i].onClick.RemoveAllListeners();

            if (answer == correctAnswer)
            {
                answerButtons[i].onClick.AddListener(() =>
                {
                    Debug.Log("Correcto");
                    puntos++;
                    Debug.Log("Puntos: " + puntos);
                    checkAnswer(true);
                });
            }
            else
            {
                answerButtons[i].onClick.AddListener(() =>
                {
                    Debug.Log("Incorrecto");
                    checkAnswer(false);
                });
            }
        }
    }

    public void checkAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            if (puntos >= 5)
            {   
                Debug.Log("Has ganado el juego");
                canvasGroup.blocksRaycasts = false;
                StartCoroutine(Second());
            }
            else if(puntos < 5)
            {
                Debug.Log("Correcto");
                GenerateNumbers();
            }
        }
        else
        {
            Debug.Log("Incorrecto - intentalo de nuevo");
        }
    }

    IEnumerator DelayedGenerate()
    {
        yield return null;
        GenerateNumbers();
    }

    IEnumerator Second()
    {
        animator.SetFloat("Felicitacion", 1);
        Debug.Log("Animacion completada");
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
