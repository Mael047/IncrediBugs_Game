using System.Collections.Generic;
using UnityEngine;

public class CharacterCustom : MonoBehaviour
{

    [Header("Sprites a cambiar")]
    public SpriteRenderer HeadParts;

    [Header("Sprites ciclicos")]
    public List<Sprite> Options = new List<Sprite>();


    private int CurrentOption = 0;


    public void NextOption()
    {
        CurrentOption++;
        if (CurrentOption >= Options.Count)
        {
            CurrentOption = 0;
        }

        HeadParts.sprite = Options[CurrentOption];
 
    }

    public void PreviousOption()
    {
        CurrentOption--;
        if (CurrentOption <= 0)
        {
            CurrentOption = Options.Count - 1;
        }
        HeadParts.sprite = Options[CurrentOption];
    }
}

