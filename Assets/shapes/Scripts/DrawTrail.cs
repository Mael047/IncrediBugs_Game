using UnityEngine;
using System.Collections.Generic;

public class DrawTrail : MonoBehaviour
{
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector2> points = new List<Vector2>();

    void Update()
    {
#if UNITY_EDITOR
        // For testing in the Unity Editor with a mouse
        if (Input.GetMouseButtonDown(0)) StartLine(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButton(0)) UpdateLine(Camera.main.ScreenToWorldPoint(Input.mousePosition));
#else
        // For mobile touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began) StartLine(touchPos);
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) UpdateLine(touchPos);
        }
#endif
    }

    void StartLine(Vector2 pos)
    {
        currentLine = Instantiate(linePrefab);
        points.Clear();
        points.Add(pos);
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, pos);
    }

    void UpdateLine(Vector2 pos)
    {
        if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], pos) > 0.05f)
        {
            points.Add(pos);
            currentLine.positionCount = points.Count;
            currentLine.SetPosition(points.Count - 1, pos);
        }
    }
}
