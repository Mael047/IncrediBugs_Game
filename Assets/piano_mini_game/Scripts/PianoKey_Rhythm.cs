using UnityEngine;
using UnityEngine.EventSystems;

public class PianoKey_Rhythm : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public string noteName;
    public AudioClip noteSound;

    private AudioSource audioSource;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = noteSound;
        audioSource.loop = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        audioSource.Play();

        foreach (var tile in FindObjectsByType<FallingNote>(FindObjectsSortMode.None)) {
            if (tile.note == noteName && Mathf.Abs(tile.GetComponent<RectTransform>().anchoredPosition.y) < 80f) {
                Debug.Log("¡Perfecto!");
                Destroy(tile.gameObject);
                break;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        audioSource.Stop();
    }
}

