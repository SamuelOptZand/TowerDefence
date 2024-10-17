using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class HpDisplayer : MonoBehaviour
{
    private float playerHealth = 100;
    [SerializeField] private TMP_Text text;
    void Start()
    {
        EnemyAI.ReachEnd += removeHP;
    }
    void Update()
    {
        text.text = "Health: " + playerHealth.ToString();

        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
    private void removeHP(GameObject gameObject)
    {
        playerHealth -= 10;
    }
}
