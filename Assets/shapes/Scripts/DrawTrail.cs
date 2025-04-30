using UnityEngine;
using System.Collections.Generic;

public class DrawTrail : MonoBehaviour
{
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector2> points = new List<Vector2>();
    private List<LineRenderer> activeLines = new List<LineRenderer>();


    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
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
        else if (Input.GetMouseButtonUp(0))
        {
            EndLine();
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
                StartLine(touchPos);
            else if (touch.phase == TouchPhase.Moved)
                UpdateLine(touchPos);
            else if (touch.phase == TouchPhase.Ended)
                EndLine();
        }
#endif
    }

    void StartLine(Vector2 position)
    {
        currentLine = Instantiate(linePrefab);
        activeLines.Add(currentLine); // Track line
        points.Clear();
        points.Add(position);
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, new Vector3(position.x, position.y, -0.1f));
    }

    void UpdateLine(Vector2 position)
    {
        if (Vector2.Distance(points[points.Count - 1], position) > 0.05f)
        {
            points.Add(position);
            currentLine.positionCount++;
            currentLine.SetPosition(currentLine.positionCount - 1, new Vector3(position.x, position.y, 0));
        }
    }

    void EndLine()
    {
        Debug.Log("🔴 End line");
        // Optionally: Add logic here to check if trace overlaps checkpoints, etc.
    }

    public void ClearLines() {
        foreach (var line in activeLines) {
            Destroy(line.gameObject);
        }
        activeLines.Clear();
    }

}
