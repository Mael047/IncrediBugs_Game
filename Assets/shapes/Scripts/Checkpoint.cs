using UnityEngine;
using UnityEngine.EventSystems;

public class Checkpoint : MonoBehaviour, IPointerEnterHandler {
    public int checkpointIndex;
    public TracingManager tracingManager;

    public void OnPointerEnter(PointerEventData eventData) {
        tracingManager.CheckpointHit(checkpointIndex);
    }
}
