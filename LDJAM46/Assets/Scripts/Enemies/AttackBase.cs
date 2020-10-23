using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{

    public BaseHealth hp;
    public float cooldown;
    public float Range;
    private float cooldowntemp;
    public float damage;
      
    void Start()
    {
        hp = GameObject.FindWithTag("Base").GetComponent<BaseHealth>();
    }

    void Update()
    {
        if (Vector3.Distance(GameObject.FindWithTag("Base").transform.position, transform.position) <= Range && cooldowntemp < 0)
        {
            cooldowntemp = cooldown;
            hp.Health -= damage;
        }
        else
            cooldowntemp -= Time.deltaTime;
    }

}
