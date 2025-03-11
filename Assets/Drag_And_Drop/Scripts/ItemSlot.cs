using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IDropHandler
{

    DragDrop Bandera;

    [Header("Banderas De este Slot")]
    public string FlagInSlot;
    private void Start()
    {
        Bandera = new DragDrop();
        Bandera.SetFlag(FlagInSlot);
        Debug.Log("La Bandera que debe ir en este slot es " + Bandera.GetFlag());
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
