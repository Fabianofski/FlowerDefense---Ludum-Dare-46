using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private int dir;
    public float maxSpeed;
    public float minSpeed;
    public float leftborder;
    public float rightborder;
    private float speed;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
        dir = Random.Range(0, 2);
        if (dir == 0)
            dir = -1;
    }


    void Update()
    {
        rb2d.velocity = transform.right * dir * speed * Time.deltaTime;

        if(transform.position.x < leftborder && dir == -1)
        {
            transform.position = new Vector2(rightborder, transform.position.y);
        }
        if(transform.position.x > rightborder && dir == 1)
        {
            transform.position = new Vector2(leftborder, transform.position.y);
        }
    }
}
