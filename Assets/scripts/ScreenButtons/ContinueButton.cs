using UnityEngine.SceneManagement;
using UnityEngine;
public class ContinueButton : MonoBehaviour
{
    public void ContinueToGame()
    {
        SceneManager.LoadScene("Game");
    }
}