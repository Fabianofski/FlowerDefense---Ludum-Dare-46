using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed;
    public bool Stunned;
    public float StunTime;
    public float Range;
    

    void Start()
    {
        if(transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {

        if(!Stunned && Vector3.Distance(GameObject.FindWithTag("Base").transform.position, transform.position) > Range)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), speed * Time.deltaTime);
    }

    public IEnumerator Stun()
    {
        Stunned = true;
        yield return new WaitForSeconds(StunTime);
        Stunned = false;
    }
}
