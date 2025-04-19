using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu]
public class CustomizedCharacter : ScriptableObject
{

    [field: SerializeField]
    public List<CustomizationData> Data { get; private set; }
    

}

