using UnityEngine;
using System;
using UnityEngine.UIElements;
public class EnemyAI : MonoBehaviour
{
    private Transform[] currentTrans;
    private GameObject pointsParent;
    private Spawner enemSpawner;
    private Transform End;
    private SpriteRenderer Sr;
    public static event Action<GameObject> ReachEnd;
    public static event Action<GameObject> KillEnem;
    private float MoveSpeed = 2f;
    private float MaxHealth = 100f;
    private int i = 1;
    private float Health = 100f;
    private Color result;
    public float hp { get { return Health; } set { Health = value; } }
    void Start()
    {
        enemSpawner = FindAnyObjectByType<Spawner>();
        Sr = GetComponent<SpriteRenderer>();
        pointsParent = GameObject.Find("Points");
        currentTrans = new Transform[5];
        currentTrans = pointsParent.GetComponentsInChildren<Transform>();
        End = currentTrans[currentTrans.Length -1];
        Spawner.IncreaseRound += IncreaseDif;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTrans[i].position, MoveSpeed * Time.deltaTime);
        result = Color.Lerp(Color.red, Color.white, Health / MaxHealth);
        Sr.color = result;
        if (transform.position == currentTrans[i].position && i < currentTrans.Length -1)
        {
            i++;
        }
        if (transform.position == End.position)
        {
            ReachEnd.Invoke(gameObject);
            Destroy(gameObject);
        }
        if (Health <= 0)
        {
            KillEnem.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
    private void IncreaseDif(GameObject gameObject)
    {
        MaxHealth += 2f;
        hp += 2f;
        MoveSpeed += 2f;
    }
}