using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Change_Color : MonoBehaviour
{
    public Color[] colores;
    public Queue<Color> QueueColor = new Queue<Color>();
    public SpriteRenderer spriteRenderer;


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

