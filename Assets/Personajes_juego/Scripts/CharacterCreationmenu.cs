using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreationmenu : MonoBehaviour
{

   public GameObject character;

   public void Sumbit()
   {
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Player.prefab");
        TransicionEscenasUI.Instance.BloqueSalida(1);
    }
}
