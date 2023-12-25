using System.Collections;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public RectTransform menuImage; 
    private bool keyPressed = false;

    void Update()
    {
        if (!keyPressed && Input.anyKeyDown)
        {
            keyPressed = true;
            StartCoroutine(MoveMenuSmoothly());
        }
    }

    IEnumerator MoveMenuSmoothly()
    {
        float duration = 0.7f; 
        float elapsedTime = 0f;
        Vector2 startPosition = menuImage.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, 0); 
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            menuImage.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        menuImage.anchoredPosition = targetPosition;
    }

    public void ResetKeyPressed()
    {
        keyPressed = false; 
    }
}
