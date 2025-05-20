using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Sumas_restas : MonoBehaviour
{
    [SerializeField] private TMP_Text numberText;
    [SerializeField] private TMP_Text numberText2;
    [SerializeField] private Button[] answerButtons;

    private int correctAnswer;

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
            numberText2.text = " + " + randomNumber2.ToString();
            correctAnswer = randomNumber1 + randomNumber2;
        }
        else
        {
            // Resta sin negativos
            int max = Mathf.Max(randomNumber1, randomNumber2);
            int min = Mathf.Min(randomNumber1, randomNumber2);

            numberText.text = max.ToString();
            numberText2.text = " - " + min.ToString();
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
            Debug.Log("Correcto");
            GenerateNumbers();
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
}
