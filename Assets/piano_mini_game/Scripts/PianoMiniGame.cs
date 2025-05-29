using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PianoMiniGame : MonoBehaviour {
    public TMP_Text questionText;
    public TMP_Text feedbackText;

    private List<string> notePool = new List<string> { "DO", "RE", "MI", "FA", "SOL", "LA", "SI" };
    private int currentIndex = 0;

    private Pantalla_Felicitacion pantalla;

    private void Start() {
        pantalla = FindAnyObjectByType<Pantalla_Felicitacion>();

        ShuffleNotes();
        NextQuestion();
    }

    void ShuffleNotes() {
        for (int i = 0; i < notePool.Count; i++) {
            int randomIndex = Random.Range(i, notePool.Count);
            string temp = notePool[i];
            notePool[i] = notePool[randomIndex];
            notePool[randomIndex] = temp;
        }
        currentIndex = 0;
    }

    public void CheckAnswer(string notePressed) {
        if (currentIndex >= notePool.Count) return;

        if (notePressed == notePool[currentIndex]) {
            feedbackText.text = "¡Correcto!";
            currentIndex++;

            if (currentIndex >= notePool.Count) {
                // Show final message
                questionText.text = "¡Felicidades! Has tocado todas las notas!";
                feedbackText.text = "";

                StartCoroutine(ShowFinalCelebration());
            } else {
                Invoke("NextQuestion", 1.5f);
            }
        } else {
            feedbackText.text = "¡Intenta de nuevo!";
        }
    }

    void NextQuestion() {
        if (currentIndex < notePool.Count) {
            questionText.text = "¡Toca la nota " + notePool[currentIndex] + "!";
            feedbackText.text = "";
        }
    }

    IEnumerator ShowFinalCelebration() {
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(pantalla.Second());
    }
}
