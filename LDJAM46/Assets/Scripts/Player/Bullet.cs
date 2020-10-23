using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float dir;
    public float lifetime;
    public GameObject bloodParticle;
    private Rigidbody2D rb2d;
    public float damage;
    private bool hit;


    public AudioSource hitSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Destroy(gameObject, lifetime);
        rb2d.velocity = dir * transform.right * speed * Time.fixedDeltaTime;  
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.GetComponent<Health>() && !hit) 
        {
            hit = true;
            hitSound.Play();
            Camera.main.GetComponent<Animator>().SetTrigger("CameraShake");

            Quaternion rotation;
            Vector3 pos;
            if (transform.position.x < GameObject.FindWithTag("Player").transform.position.x)
            { 
                rotation = new Quaternion(0, 180, 0, 0);
                pos = new Vector3(collider.transform.position.x + 0.2f, transform.position.y);
            }
            else
            {
                rotation = Quaternion.identity;
                pos = new Vector3(collider.transform.position.x - 0.2f, transform.position.y);
            }

            GameObject particle = Instantiate(bloodParticle, pos, rotation, collider.transform);
            Destroy(particle, 1f);
            collider.gameObject.GetComponent<Health>().hp -= damage;
            collider.gameObject.GetComponent<Health>().StartCoroutine("Pulse");
            collider.gameObject.GetComponent<SimpleMovement>().StartCoroutine("Stun");
            Destroy(gameObject);
        }


    }
}
