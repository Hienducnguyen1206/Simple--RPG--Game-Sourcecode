using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }


    
}
