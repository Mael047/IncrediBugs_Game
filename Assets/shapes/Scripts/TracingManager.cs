using UnityEngine;
using System.Collections;

public class TracingManager : MonoBehaviour {
    public GameObject[] numberPanels;
    public DrawTrail drawTrail;
    public int currentCheckpoint = 0;
    public int totalCheckpoints = 4;
    private int currentNumberIndex = 0;

    [SerializeField] private AudioClip sonidoNumero1;
    [SerializeField] private AudioClip sonidoNumero2;
    [SerializeField] private AudioClip sonidoNumero3;

    private Pantalla_Felicitacion pantalla;

    private void Awake()
    {
        pantalla = FindAnyObjectByType<Pantalla_Felicitacion>();
        if (currentNumberIndex == 0)
        {
            ControladorSonido.Instance.EjecutarSonido(sonidoNumero1);
        }
    }

    public void CheckpointHit(int index) {
        if (index == currentCheckpoint) {
            currentCheckpoint++;

            if (currentCheckpoint >= totalCheckpoints) {
                Debug.Log("bien!");
                StartCoroutine(TransitionToNextNumber());
            }
        }
        
        else {
            Debug.Log("ese no es");
        }
    }

    IEnumerator TransitionToNextNumber() {
        drawTrail.ClearLines();

        CanvasGroup currentCG = numberPanels[currentNumberIndex].GetComponent<CanvasGroup>();

        for (float t = 0; t < 1f; t += Time.deltaTime) {
            currentCG.alpha = 1f - t;
            yield return null;
        }
        currentCG.alpha = 0;
        currentCG.gameObject.SetActive(false);

        currentNumberIndex++;

        if (currentNumberIndex < numberPanels.Length) {
            GameObject nextPanel = numberPanels[currentNumberIndex];
            CanvasGroup nextCG = nextPanel.GetComponent<CanvasGroup>();
            nextPanel.SetActive(true);
            nextCG.alpha = 0;
           
            if (currentNumberIndex == 1)
            {
                ControladorSonido.Instance.EjecutarSonido(sonidoNumero2);
            }
            else if (currentNumberIndex == 2)
            {
                ControladorSonido.Instance.EjecutarSonido(sonidoNumero3);
            }
            for (float t = 0; t < 1f; t += Time.deltaTime) {
                nextCG.alpha = t;
                yield return null;
            }
            nextCG.alpha = 1f;

            currentCheckpoint = 0;
        }
        else {
            drawTrail.canDraw = false;
            StartCoroutine(pantalla.Second());
            Debug.Log("todos completados");
        }
    }
}