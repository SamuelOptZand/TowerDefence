using TMPro;
using UnityEngine;
public class RoundDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text roundtext;
    [SerializeField] private Spawner spawner;
    void Update()
    {
        roundtext.text = "Round: " + spawner.Rounds.ToString();
    }
}