using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CustomizableCharacter : MonoBehaviour
{
    [SerializeField]
    private CustomizedCharacter _characterTemplate; // Solo para referencia

    private static List<CustomizationData> _customizationDataCache = new(); // Runtime cache

    public static List<CustomizationData> CachedData => _customizationDataCache;

    public void StoreCustomizationInformation()
    {
        var elements = GetComponentsInChildren<CustomizableElement>();
        _customizationDataCache.Clear();
        foreach (var element in elements)
        {
            _customizationDataCache.Add(element.GetCustomizationData());
        }

        // Cambia de escena
        TransicionEscenasUI.Instance.BloqueSalida(1);
    }
}
