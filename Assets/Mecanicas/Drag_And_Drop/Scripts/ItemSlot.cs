using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public Points_Flags pointsFlags;

    [Header("Slot")]
    public string FlagInSlot;

    private void Start()
    {
        Debug.Log("El Item que va en este Slot es " + FlagInSlot);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            DragDrop banderaArrastrada = eventData.pointerDrag.GetComponent<DragDrop>();
            if (banderaArrastrada != null)
            {
                if (FlagInSlot == banderaArrastrada.GetFlag()) // EN caso de que el item sea correcto ajusta su posición y lo deja en el slot   
                {
                    Debug.Log("Correcto");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    banderaArrastrada.transform.SetParent(transform);
                    pointsFlags.AddPoint();
                    pointsFlags.HorsePoint();

                }
                else if(FlagInSlot != banderaArrastrada.GetFlag()) // En caso de que el item sea incorrecto lo regresa a su posición original
                {
                    Debug.Log("Incorrecto");
                    banderaArrastrada.ReturnToOriginalPosition();
                }
            }
        }
    }
}