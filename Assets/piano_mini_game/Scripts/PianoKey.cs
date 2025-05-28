using UnityEngine;
using UnityEngine.EventSystems;

public class PianoKey : MonoBehaviour, IPointerDownHandler {
    public string noteName;
    public AudioClip noteSound;
    public PianoMiniGame game;

    private AudioSource audioSource;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = noteSound;
        audioSource.loop = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        audioSource.Stop();
        audioSource.Play();
        if (game != null)
        {
            game.CheckAnswer(noteName);
        }
    }
}
