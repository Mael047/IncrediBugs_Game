using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;

    [Header("item")]
    public string SelectedFlag;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        Debug.Log("El item seleccionado es" + SelectedFlag);
    }

    public string GetFlag()
    {
        return SelectedFlag;
    }

    public void SetFlag(string flag)
    {
        SelectedFlag = flag;
 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        originalPosition = transform.position;
        originalParent = transform.parent;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == originalParent)
        {
            transform.position = originalPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
        transform.SetParent(originalParent);
    }
}