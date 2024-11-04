using TMPro;
using UnityEngine;
using System.Collections;

public class TitleMovement : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public Vector2 position;
    private float timer = 0;

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

    //void FixedUpdate()
    //{
    //    StartCoroutine(TitleAnimation());

    //}
    //IEnumerator TitleAnimation()
    //{

    //    //yield return new WaitForSeconds(pauseTime);

    //}
}