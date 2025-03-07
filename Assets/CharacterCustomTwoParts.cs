using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomTwoParts: MonoBehaviour
{

    [Header("Sprites a cambiar")]
    public SpriteRenderer HeadPartsDer;
    public SpriteRenderer HeadPartsIzq;

    [Header("Sprites ciclicos")]
    public List<Sprite> OptionsDer = new List<Sprite>();
    public List<Sprite> OptionsIzq = new List<Sprite>();

    private int CurrentOption = 0;


    public void NextOption()
    {
        CurrentOption++;
        if (CurrentOption >= OptionsDer.Count )
        {
            CurrentOption = 0;
        }

        HeadPartsDer.sprite = OptionsDer[CurrentOption];
        HeadPartsIzq.sprite = OptionsIzq[CurrentOption];   
    }

    public void PreviousOption()
    {
        CurrentOption--;
        if (CurrentOption <= 0)
        {
            CurrentOption = OptionsDer.Count - 1 ;
            CurrentOption = OptionsIzq.Count - 1;
        }

        HeadPartsDer.sprite = OptionsDer[CurrentOption]; 
        HeadPartsIzq.sprite = OptionsIzq[CurrentOption];   

    }


}

