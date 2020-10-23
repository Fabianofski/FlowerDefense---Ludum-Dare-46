using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sprint;
    public float jumpspeed;

    public float hormov;
    private Rigidbody2D rb2d;

    public LayerMask ground;
    public bool onGround;
    public Transform feet;
    public float radius = 0.2f;

    private bool FacingRight;
    public GameObject SpriteGO;

    public AudioSource jumpSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // horizontal movement set to Input (A = -1; D = 1)
        hormov = Input.GetAxis("Horizontal");

        // Walking and Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.velocity = new Vector2(hormov * speed * sprint * Time.fixedDeltaTime, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(hormov * speed * Time.fixedDeltaTime, rb2d.velocity.y);
        }

        // Jump when On Ground and when Space or W pressed
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (onGround)
            {
                jumpSound.Play();
                rb2d.velocity = Vector2.up * jumpspeed * Time.fixedDeltaTime;
            }

        }
    }

    void Update()
    {
        // Check if on Ground
        onGround = Physics2D.OverlapCircle(feet.position, radius, ground);

        if (hormov > 0)
        {
            SpriteGO.transform.eulerAngles = new Vector3(SpriteGO.transform.eulerAngles.x, 0, SpriteGO.gameObject.transform.eulerAngles.z);
            SpriteGO.GetComponent<Animator>().SetBool("Walk", true);
        }
        else if (hormov < 0)
        {
            SpriteGO.transform.eulerAngles = new Vector3(SpriteGO.transform.eulerAngles.x, 180, SpriteGO.transform.eulerAngles.z);
            SpriteGO.GetComponent<Animator>().SetBool("Walk", true);
        }
        else
            SpriteGO.GetComponent<Animator>().SetBool("Walk", false);
    }
}
