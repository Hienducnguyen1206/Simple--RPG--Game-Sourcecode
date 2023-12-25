using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button button;
    public Sprite pressedSprite;
    private Sprite normalSprite;

    void Start()
    {
        normalSprite = button.image.sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (pressedSprite != null)
        {
            button.image.sprite = pressedSprite;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (normalSprite != null)
        {
            button.image.sprite = normalSprite;
        }
    }
}
