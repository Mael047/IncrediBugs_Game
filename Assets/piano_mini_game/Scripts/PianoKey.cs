using UnityEngine;
using UnityEngine.EventSystems;

public class PianoKey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public string noteName;
    public AudioClip noteSound;
    public PianoMiniGame game;

    private AudioSource audioSource;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = noteSound;
        audioSource.loop = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        audioSource.Play();
        if (game != null)
        {
            game.CheckAnswer(noteName);
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        audioSource.Stop();
    }
}
