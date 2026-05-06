 using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject creditobj;
    public float speed = 2.5f;
    public RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        rect.anchoredPosition = new Vector2(0, speed* Time.deltaTime);
    }
}
