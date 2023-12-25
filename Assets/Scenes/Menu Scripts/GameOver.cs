using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public RectTransform menuImage; 
    public PlayerController playerController;


    void Update()
    {
        if (playerController != null)
        {
            if (playerController.isDead == false )
            {
                GameOverMenu();
            }
            
        }
       
    }
    public void GameOverMenu()
    {



        StartCoroutine(MoveMenuSmoothly());

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


}
