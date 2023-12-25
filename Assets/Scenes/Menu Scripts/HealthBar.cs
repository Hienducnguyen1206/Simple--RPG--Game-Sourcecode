
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private  PlayerController playerController;
    public Slider healthBar;
    public Text HPtext;
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
    void Update()
    {
        healthBar.maxValue = playerController.maxHeath;
        healthBar.value = playerController.currentHeath;
        HPtext.text = healthBar.value.ToString();     
    }
}
