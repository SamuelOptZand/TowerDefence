using TMPro;
using UnityEngine;
public class Greedygrinner : MonoBehaviour
{
    [SerializeField] private TMP_Text MoneyDisplay;
    private float dollas;
    public float Money { get { return dollas; } set { dollas = value; } }
    void Start()
    {
        EnemyAI.KillEnem += AddMoney;
        dollas += 10;
    }
    void Update()
    {
        MoneyDisplay.text = "Money: €" + Money.ToString();
    }
    private void AddMoney(GameObject gameObject)
    {
        dollas += 1f;
    }
}
