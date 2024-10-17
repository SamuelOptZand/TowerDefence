using UnityEngine.SceneManagement;
using UnityEngine;
public class DeathScreen : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene("Start");
    }
    public void QuitToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }
}