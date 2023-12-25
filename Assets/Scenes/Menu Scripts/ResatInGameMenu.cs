using System.Collections;
using UnityEngine;

public class ResetInGameMenu : MonoBehaviour
{
    public RectTransform menuImage;
    public float duration = 0.7f;

    private Vector2 startPosition;
    private Vector2 targetPosition = new Vector2(0, -750);

    void Start()
    {
        startPosition = menuImage.anchoredPosition;
    }

    public void ResetMenu()


    {
        StartCoroutine(ResetMenuPositionCoroutine());
    }


    IEnumerator ResetMenuPositionCoroutine()
    {
        float elapsedTime = 0f;
        Vector2 currentPosition = menuImage.anchoredPosition;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            menuImage.anchoredPosition = Vector2.Lerp(currentPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        menuImage.anchoredPosition = targetPosition; 
        
    }
}
