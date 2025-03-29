using UnityEngine;
using UnityEngine.UI;

public class FallingNote : MonoBehaviour{
    public string note;
    public float duration;
    public float fallSpeed = 200f;

    private RectTransform rt;

    void Start() {
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100f, duration * 260f);
    }

    void Update() {
        rt.anchoredPosition -= new Vector2(0, fallSpeed * Time.deltaTime);

        if (rt.anchoredPosition.y < -236f)
            Destroy(gameObject);
    }
}
