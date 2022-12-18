using UnityEngine;
using UnityEngine.UI;

public class MakeBigger : MonoBehaviour
{
    public float scaleFactor = 2f;
    public float animationDuration = 1f;

    private RectTransform rectTransform;
    private Vector2 initialSize;
    private Vector2 targetSize;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private float animationStartTime;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialSize = rectTransform.sizeDelta;
        targetSize = initialSize * scaleFactor;
        initialPosition = rectTransform.anchoredPosition;
        targetPosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animationStartTime = Time.time;
        }

        if (Time.time - animationStartTime <= animationDuration)
        {
            float t = (Time.time - animationStartTime) / animationDuration;
            rectTransform.sizeDelta = Vector2.Lerp(initialSize, targetSize, t);
            rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);
        }
    }
}
