using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour
{
    private Transform target;
    private EnemyAI targetscript;
    private List<GameObject> InRange = new List<GameObject>();
    private LineRenderer lineRenderer;
    private float AtkPwr = 1f;
    private bool enablerange = false;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.startWidth = 0.1f;
        Dragable.DoneDragging += Donedrag;
        UpgradeButton.UpgradeT += upgrade;

    }
    void Update()
    {
        if (InRange.Count > 0)
        {
            target = InRange[0].transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D enemy) 
    {
        
        if (enablerange == true)
        {
            if (enemy.CompareTag("enemy"))
            {
                if (!InRange.Contains(enemy.gameObject))
                { 
                    InRange.Add(enemy.gameObject);
                    targetscript = InRange[0].GetComponent<EnemyAI>();  
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D enemy)
    {
        if(enablerange == true)
        {
            if (enemy.CompareTag("enemy"))
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, target.position);
                lineRenderer.enabled = true;
                targetscript.hp -= AtkPwr;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enablerange == true)
        {
            InRange.Remove(enemy.gameObject);
            if (InRange.Count == 0)
            {
                lineRenderer.enabled = false;
            }
        }   
    }
    private void Donedrag(GameObject gameObject)
    {
        enablerange = true;
    }
    private void upgrade(GameObject gameObject)
    {
        AtkPwr += 1f;
    }
}