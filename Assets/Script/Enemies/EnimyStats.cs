using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public EnimeSciptableObject enemyData;

    //current status
    [HideInInspector]
    public float currentMovespeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamge;

    public float derespawnDistance = 20f;
    Transform player;


    void Awake()
    {
        currentDamge = enemyData.Damage;
        currentHealth = enemyData.MaxHealth;
        currentMovespeed = enemyData.MoveSpeed;
    }
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= derespawnDistance)
        {
            ReturnEnemy();
        }
    }


    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth < 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamge(currentDamge);
        }
    }
    private void OnDestroy()
    {
        EnemySpawn es = FindObjectOfType<EnemySpawn>();
        es.OnEnemyKilled();
    }
    void ReturnEnemy()
    {
        EnemySpawn es = FindObjectOfType<EnemySpawn>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}
