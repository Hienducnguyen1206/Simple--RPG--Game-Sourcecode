using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
