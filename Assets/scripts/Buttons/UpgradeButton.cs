using System;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public static event Action<GameObject> UpgradeT;
    [SerializeField] private Greedygrinner moneyscript;
    void Start()
    {
        FindAnyObjectByType(typeof(Tower));
    }
    public void UpgradeTower()
    {
        if(moneyscript.Money >= 10)
        {
            moneyscript.Money -= 10f;
            UpgradeT?.Invoke(gameObject);
        }
    }
}