using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Header("Banderas De este Slot")]
    public string FlagInSlot;

    private void Start()
    {
        Debug.Log("La Bandera que debe ir en este slot es " + FlagInSlot);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            DragDrop banderaArrastrada = eventData.pointerDrag.GetComponent<DragDrop>();
            if (banderaArrastrada != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                if (FlagInSlot == banderaArrastrada.GetFlag())
                {
                    Debug.Log("Correcto");
                }
                else
                {
                    Debug.Log("Incorrecto");
                }
            }
        }
    }
}