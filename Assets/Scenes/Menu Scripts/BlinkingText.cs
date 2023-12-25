using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public float blinkInterval = 0.5f;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("ToggleTextVisibility", 0f, blinkInterval);
    }

    void ToggleTextVisibility()
    {
        textMeshPro.enabled = !textMeshPro.enabled;
    }
}
