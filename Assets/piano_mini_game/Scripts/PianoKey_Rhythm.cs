using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PianoKey_Rhythm : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public string noteName;
    public AudioClip noteSound;

    private AudioSource audioSource;
    private Pantalla_Felicitacion pantalla;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = noteSound;
        audioSource.loop = true;

        pantalla = FindAnyObjectByType<Pantalla_Felicitacion>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        audioSource.Play();

        foreach (var tile in FindObjectsByType<FallingNote>(FindObjectsSortMode.None)) {
            if (tile.note == noteName && Mathf.Abs(tile.GetComponent<RectTransform>().anchoredPosition.y) < 80f) {
                Debug.Log("¡Perfecto!");
                Destroy(tile.gameObject);
                Invoke(nameof(CheckIfGameFinished), 0.1f);
                break;
            } 
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        audioSource.Stop();
    }
    private void CheckIfGameFinished()
    {
        var remainingNotes = FindObjectsByType<FallingNote>(FindObjectsSortMode.None);
        if (remainingNotes.Length == 0)
        {
            Debug.Log("¡Juego Terminado!");
            StartCoroutine(pantalla.Second());
        }

    }
}


