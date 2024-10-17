using System;
using UnityEngine;
public class Dragable : MonoBehaviour
{
    private bool isDraggable = true;
    public static event Action<GameObject> DoneDragging;
    void Update()
    {
        if (isDraggable == true)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
    private void OnMouseDown()
    {
        isDraggable = false;
        DoneDragging.Invoke(gameObject);
    }
}