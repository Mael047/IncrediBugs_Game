using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicio : MonoBehaviour
{
    public void Jugar()
    {
        TransicionEscenasUI.Instance.BloqueSalida(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Personalizar()
    {
        TransicionEscenasUI.Instance.BloqueSalida(2);
    }

}
