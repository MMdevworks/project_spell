using TMPro;
using UnityEngine;
using System.Collections;

// Assigned to Game Title; control intro animation
public class TitleMovement : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    private Vector2 position = new Vector2(5.3663f, 34);
    private float timer = 0;

    // RectTransform - manipulate UI elements; move from start position to new position over time;
    void Update()
    {
        RectTransform textRectTransform = titleText.GetComponent<RectTransform>();
        textRectTransform.anchoredPosition = Vector2.Lerp(textRectTransform.anchoredPosition, position, Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > 4 )
        {
            titleText.gameObject.SetActive(false);
        }
    }
}