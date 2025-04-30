using UnityEngine;
using UnityEngine.EventSystems;

public class Checkpoint : MonoBehaviour, IPointerEnterHandler
{
    public int checkpointIndex; // Set this in Inspector
    public TracingManager tracingManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tracingManager.CheckpointHit(checkpointIndex);
    }
}
