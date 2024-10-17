using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPre;
    [SerializeField] private Transform StartPos;
    [SerializeField] private List<GameObject> Enemylist = new List<GameObject>();
    public static event Action<GameObject> IncreaseRound;
    private float level;
    public float Rounds { get { return level; }}
    void Start()
    {
        level = 1;
        EnemyAI.ReachEnd += enemykill;
        EnemyAI.KillEnem += enemykill;
        StartCoroutine(Spawning());
    }
    void Update()
    {
        if (Enemylist.Count == 0)
        {
            level++;
            if (level % 2 == 0)
            {
                IncreaseRound.Invoke(gameObject);
            }
            StartCoroutine(Spawning());
        }
    }
    private IEnumerator Spawning()
    {
        while (Enemylist.Count < level) 
        {
            GameObject NewEnemy = Instantiate(EnemyPre, StartPos.position, Quaternion.identity);
            Enemylist.Add(NewEnemy);

            yield return new WaitForSeconds(0.5f);
        }
    }
    private void enemykill(GameObject gameObject)
    {
        Enemylist.Remove(gameObject);
    }
}