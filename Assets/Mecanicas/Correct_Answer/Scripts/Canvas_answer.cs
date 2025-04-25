using UnityEngine;

public class Canvas_answer : MonoBehaviour
{
    [Header("Canvas Actual")]
    public Canvas canvasActual;

    [Header("Proximo Canvas")]
    public Canvas ProximoCanvas;

    private void CambiarCanvas()
    {
        if (canvasActual != null)
            canvasActual.gameObject.SetActive(false);

        if (ProximoCanvas != null)
            ProximoCanvas.gameObject.SetActive(true);
    }

    
}
