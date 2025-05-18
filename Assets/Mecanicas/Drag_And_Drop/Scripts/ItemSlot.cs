using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public Points_Flags pointsFlags;

    [Header("Slot")]
    public string FlagInSlot;

    [SerializeField] private AudioClip sonidoCorrecto;
    [SerializeField] private AudioClip sonidoIncorrecto;

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
                    pointsFlags.AddPoint();
                    pointsFlags.HorsePoint();
                    Debug.Log("Correcto");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    banderaArrastrada.transform.SetParent(transform);        
                    Debug.Log("Reproduciendo sonido correcto");
                    ControladorSonido.Instance.EjecutarSonido(sonidoCorrecto);
                    
                }
                else if(FlagInSlot != banderaArrastrada.GetFlag()) 
                {
                    Debug.Log("Incorrecto");
                    banderaArrastrada.ReturnToOriginalPosition();
                    ControladorSonido.Instance.EjecutarSonido(sonidoIncorrecto);
                }
            }
        }
    }
}