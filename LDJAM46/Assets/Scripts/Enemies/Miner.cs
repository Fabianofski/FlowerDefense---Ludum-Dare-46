using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{

    public float minDigTime;
    public float maxDigTime;
    public float minstarttime;
    public float maxstarttime;

    public BoxCollider2D MineCollider;
    public BoxCollider2D BaseCollider;

    private bool Up;
    private bool x;
    public float speed;
    public float upmovement;
    public float maxX;
    public GameObject Particle;

    public SpriteRenderer sr;

    void Start()
    {
        StartCoroutine(Mine());
    }

    void Update()
    {
        if(transform.position.x < maxX && transform.position.x > -maxX)
        {
            Up = true;
            MineCollider.enabled = false;
            BaseCollider.enabled = true;
            sr.sortingOrder = 0;
            Particle.SetActive(false);
        }

        if (Up && !x)
        {
            x = true;
            transform.position = new Vector2(transform.position.x, transform.position.y + upmovement);
        }

    }

    IEnumerator Mine()
    {
        yield return new WaitForSeconds(Random.Range(minstarttime, maxstarttime));

        MineCollider.enabled = true;
        BaseCollider.enabled = false;
        sr.sortingOrder = -3;
        if(Particle)
            Particle.SetActive(true);

        yield return new WaitForSeconds(Random.Range(minDigTime, maxDigTime));

        Up = true;
        MineCollider.enabled = false;
        BaseCollider.enabled = true;
        sr.sortingOrder = 0;
        Particle.SetActive(false);
    } 

}
