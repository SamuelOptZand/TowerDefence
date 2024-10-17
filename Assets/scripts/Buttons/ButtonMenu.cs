using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;
    public void OpenMenu()
    {
        button.SetActive(false);
        menu.SetActive(true);
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
        button.SetActive(true);
    }
}
