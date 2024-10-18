using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour
{
    private Transform target;
    private EnemyAI targetscript;
    private List<GameObject> InRange = new List<GameObject>();
    private LineRenderer lineRenderer;
    private float AtkPwr = 5f;
    private bool enablerange = false;
    private bool EnemiesToAttack = false;
    private bool IntervalLimiter = false;
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
            if(EnemiesToAttack == true)
            {
                Attack();
                if(IntervalLimiter == false)
                {   
                    StartCoroutine(AttackInterval());
                    IntervalLimiter = true;
                }
            }
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
                    EnemiesToAttack = true;
                }
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
                EnemiesToAttack = false;
                StopCoroutine(AttackInterval());
            }
        }   
    }
    private void Donedrag(GameObject gameObject)
    {
        enablerange = true;
    }
    private void upgrade(GameObject gameObject)
    {
        AtkPwr += 5f;
    }
    private void Attack()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.position);
        lineRenderer.enabled = true;
    }
    private IEnumerator AttackInterval()
    {
        targetscript.hp -= AtkPwr;
        yield return new WaitForSeconds (0.2f);
        IntervalLimiter = false;
    }
}