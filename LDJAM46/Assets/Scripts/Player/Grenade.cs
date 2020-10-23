using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float radius;
    public float damage;
    public float dir;
    public Rigidbody2D rb2d;
    public float ForceX;
    public float ForceY;
    public Vector2 Playerspeed;
    public GameObject Particles;
    public AudioSource ExplosionSound;
    public GameObject hitSound;

    void Start()
    {
        StartCoroutine(Explode());
        rb2d.AddForce(new Vector2(dir * ForceX, ForceY) + Playerspeed, ForceMode2D.Impulse);
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        Detonate();
    }

    void Detonate()
    {
        ExplosionSound.Play();
        Camera.main.GetComponent<Animator>().SetTrigger("CameraShake");
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i].GetComponent<Health>())
            {
                GameObject s = Instantiate(hitSound);
                Destroy(s,1f);


                collider[i].GetComponent<Health>().hp -= damage;
            }
        }
        StartCoroutine(FadeOut());
        GameObject g = Instantiate(Particles, transform.position, Quaternion.identity);
        Destroy(g, 3f);
        Destroy(gameObject, 2.5f);
    }

    IEnumerator FadeOut()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a -= 0.1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeOut());
    }

}
