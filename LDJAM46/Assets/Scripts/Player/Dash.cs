using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public bool DashReady;
    public float dashcooldown;
    private float dashtemp;
    private bool FacingRight;

    private Vector2 target;
    public Vector2 dashrange;
    public float speed;
    private bool Go;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashtemp <= 0)
        {
            dashtemp = dashcooldown;
            DashReady = true;
        }
        else
            dashtemp -= Time.deltaTime;

        if (Input.GetAxis("Horizontal") > 0.01)
        {
            FacingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < -0.01)
            FacingRight = false;

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.E))
        {
            if (DashReady)
            {
                DashReady = false;
                if(FacingRight)
                    target = new Vector2(transform.position.x, transform.position.y) + dashrange;
                else
                    target = new Vector2(transform.position.x, transform.position.y) - dashrange;

                StartCoroutine(Dashing());
            }
        }

        if(Go)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    IEnumerator Dashing()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<BetterJump>().enabled = false;
        yield return new WaitForSeconds(0.02f);
        Go = true;
        yield return new WaitForSeconds(0.3f);
        Go = false;
        yield return new WaitForSeconds(0.02f);
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<BetterJump>().enabled = true;
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
