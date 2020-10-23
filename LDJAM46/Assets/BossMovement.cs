using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector2 botleft;
    public Vector2 topright;

    public bool AttackPhase;
    public Vector3 target;
    public float speed;

    public Vector3 AttackPos;
    public Spawner spawner;
    public int AttackPhases;
    private int currentPhase = 1;
    private int EnemiesAlive;
    private int EnemiesTotal;
    private Health health;
    private float maxhp;
    public GameObject Effects;

    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Spawner").GetComponent<WaveHandler>().enabled = false;
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        spawner.EnemyWave.AddRange(enemies);
        spawner.enemiesAlive = enemies.Count;
        spawner.enemiesTotal = enemies.Count;
        health = GetComponent<Health>();
        maxhp = health.hp;
        target = new Vector3(Random.Range(botleft.x, topright.x), Random.Range(botleft.y, topright.y) , 0) ;
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesAlive = spawner.enemiesAlive;

        if(EnemiesAlive == 0)
        {
            AttackPhase = true;
        }

        if (!AttackPhase)
        {
            if(transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }
            else
            {
                target = new Vector3(Random.Range(botleft.x, topright.x), Random.Range(botleft.y, topright.y), 0);
            }
        }
        else
        {
            Effects.SetActive(true);
            spawner.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, AttackPos, speed * Time.deltaTime);
            if(health.hp <= maxhp - currentPhase * (maxhp / AttackPhases))
            {
                Effects.SetActive(false);
                spawner.Multiplier = spawner.Multiplier * 2;
                currentPhase++;
                spawner.enabled = true;
                spawner.EnemyWave.AddRange(enemies);
                spawner.enemiesTotal = enemies.Count;
                spawner.enemiesAlive = enemies.Count;
                AttackPhase = false;
            }
        }
    }
}
