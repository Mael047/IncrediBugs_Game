using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NumberManager : MonoBehaviour
{
    public List<Sprite> numberSprites; // List of numbers (1,2,3)
    public Image numberImage; // The Image component to change
    private int currentIndex = 0;

    public List<Transform> checkpoints; // All checkpoints parent

    public DrawTrail drawTrail; // Reference to drawing script

    void Start()
    {
        LoadNumber(0);
    }

    public void NextNumber()
    {
        currentIndex++;
        if (currentIndex >= numberSprites.Count)
        {
            Debug.Log("All numbers completed!");
            return;
        }
        LoadNumber(currentIndex);
    }

    void LoadNumber(int index)
    {
        numberImage.sprite = numberSprites[index];
        
        // Reset checkpoints
        Transform checkpointParent = checkpoints[index];
        List<Transform> checkpointList = new List<Transform>();
        foreach (Transform child in checkpointParent)
        {
            checkpointList.Add(child);
        }
        drawTrail.checkpoints = checkpointList;
    }
}
