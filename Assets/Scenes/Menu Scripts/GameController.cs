using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
  
    public Transform enemyObject;
    public RectTransform menuImage;

    void Update()
    {
        
        if (enemyObject.childCount == 0)
        {
            WinningMenu();
        }
    }

    public void WinningMenu()
    {
        StartCoroutine(MoveWinningMenu());
    }
    IEnumerator MoveWinningMenu()
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
}
