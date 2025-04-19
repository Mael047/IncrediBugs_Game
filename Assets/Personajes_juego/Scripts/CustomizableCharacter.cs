using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CustomizableCharacter : MonoBehaviour
{
    [SerializeField]
    private CustomizedCharacter _character;
    public void StoreCustomizationInformation()
    {
        var elements = GetComponentsInChildren<CustomizableElement>();
        _character.Data.Clear();
        foreach (var element in elements)
        {
            _character.Data.Add(element.GetCustomizationData());
        }
        TransicionEscenasUI.Instance.BloqueSalida(1);
    }
}
