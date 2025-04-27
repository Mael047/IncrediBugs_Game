using UnityEngine;
using System.Collections.Generic;

public class DrawTrail : MonoBehaviour
{
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector2> points = new List<Vector2>();

    public List<Transform> checkpoints;
    private HashSet<Transform> passedCheckpoints = new HashSet<Transform>();
    public float checkpointRadius = 0.5f; // how close you need to be

    public NumberManager numberManager; // reference to manage numbers

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateLine(mousePos);
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                StartLine(touchPos);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                UpdateLine(touchPos);
            }
        }
#endif
    }

    void StartLine(Vector2 startPos)
    {
        currentLine = Instantiate(linePrefab);
        points.Clear();
        points.Add(startPos);
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, startPos);
        passedCheckpoints.Clear();
    }

    void UpdateLine(Vector2 newPos)
    {
        if (Vector2.Distance(points[points.Count - 1], newPos) > 0.1f)
        {
            points.Add(newPos);
            currentLine.positionCount++;
            currentLine.SetPosition(currentLine.positionCount - 1, newPos);

            CheckCheckpoint(newPos);
        }
    }

    void CheckCheckpoint(Vector2 pos)
    {
        foreach (Transform checkpoint in checkpoints)
        {
            if (!passedCheckpoints.Contains(checkpoint))
            {
                if (Vector2.Distance(checkpoint.position, pos) < checkpointRadius)
                {
                    passedCheckpoints.Add(checkpoint);
                }
            }
        }

        // If all checkpoints are passed
        if (passedCheckpoints.Count == checkpoints.Count)
        {
            Debug.Log("Number drawn correctly!");
            numberManager.NextNumber();
        }
    }
}
