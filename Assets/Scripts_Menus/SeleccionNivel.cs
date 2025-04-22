using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SeleccionNivel : MonoBehaviour
{
    
    public void CambiarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    public void CambiarNivel(int numeroNivel)
    {
        //SceneManager.LoadScene(numeroNivel);
        TransicionEscenasUI.Instance.BloqueSalida(numeroNivel);
    }

}
