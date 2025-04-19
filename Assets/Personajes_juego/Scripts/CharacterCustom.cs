using System.Collections.Generic;
using UnityEngine;

public class CharacterCustom : MonoBehaviour
{

    [Header("Sprites a cambiar")]
    public SpriteRenderer HeadParts;

    [Header("Sprites ciclicos")]
    public List<Sprite> Options = new List<Sprite>();

    [Header("Colores")]
    public Color[] colores;
    public Queue<Color> QueueColor = new Queue<Color>();
    public SpriteRenderer spriteRenderer;

    private int CurrentOption = 0;

    //Script para botones 
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

    //parte de colores
    public void Start()
    {
        foreach (Color c in colores)
        {
            QueueColor.Enqueue(c);
        }
    }
    public void NextColor()
    {
        Color c = QueueColor.Dequeue();
        spriteRenderer.color = c;
        QueueColor.Enqueue(c);
    }
}

