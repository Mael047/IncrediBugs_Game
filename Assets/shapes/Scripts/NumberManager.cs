using UnityEngine;
using System.Collections.Generic;

public class NumberManager : MonoBehaviour {
    public List<GameObject> numberGroups;
    private int currentIndex = 0;

    public DrawTrail drawTrail;

    void Start() {
        LoadNumber(0);
    }

    public void NextNumber() {
        currentIndex++;

        if (currentIndex >= numberGroups.Count) {
            Debug.Log("números completados");
            return;
        }

        LoadNumber(currentIndex);
    }

    void LoadNumber(int index) {
        for (int i = 0; i < numberGroups.Count; i++) {
            numberGroups[i].SetActive(false);
        }

        numberGroups[index].SetActive(true);

        List<Transform> checkpointList = new List<Transform>();
        foreach (Transform child in numberGroups[index].transform) {
            if (child.name.Contains("Checkpoint"))
                checkpointList.Add(child);
        }

        drawTrail.checkpoints = checkpointList;
    }
}
