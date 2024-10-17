using UnityEngine;
public class TowerButton1 : MonoBehaviour
{
    [SerializeField] private GameObject Openbutton;
    [SerializeField] private GameObject Towerprefab;
    [SerializeField] private GameObject menu;
    [SerializeField] private Greedygrinner moneyscript;
    void Start()
    {
        Dragable.DoneDragging += GiveBackMenuButton;
    }
    public void spawntower()
    {
        if (moneyscript.Money >= 5)
        {
            menu.SetActive(false);
            Openbutton.SetActive(false);
            Instantiate(Towerprefab);
            moneyscript.Money -= 5;
        }
    }
    private void GiveBackMenuButton(GameObject gameObject)
    { 
        Openbutton.SetActive(true); 
    }
}