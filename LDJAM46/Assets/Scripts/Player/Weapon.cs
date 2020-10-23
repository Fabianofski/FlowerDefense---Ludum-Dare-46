using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Vector2 pos;
    public GameObject Bullet;
    public GameObject Grenade;

    public float cooldown;
    public float cooldowntemp;
    public TextMeshProUGUI Grenadetext;

    public float Grenades = 3;
    public float maxGrenades = 3;
    public float lifetime;
    public float damage;

    public bool FacingRight;
    public Animator anim;
    public GrenadeCooldown gc;

    public GameObject weaponSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            FacingRight = true;
        }
        else if(Input.GetAxis("Horizontal") < -0.01)
        {
            FacingRight = false;
        }

        Grenadetext.text = Grenades + "";

        if (Input.GetMouseButton(0) && cooldowntemp < 0)
        {
            GameObject g = Instantiate(weaponSound);
            Destroy(g,2f);

            anim.SetTrigger("Shoot");
            Camera.main.GetComponent<Animator>().SetTrigger("CameraShake");

            if (FacingRight)
            {
                GameObject bull = Instantiate(Bullet, new Vector2(transform.position.x +pos.x, transform.position.y+pos.y), Quaternion.identity);
                bull.GetComponent<Bullet>().dir = 1;
                bull.GetComponent<Bullet>().lifetime = lifetime;
                bull.GetComponent<Bullet>().damage = damage;
            }
            else
            {
                GameObject bull = Instantiate(Bullet, new Vector2(transform.position.x -pos.x, transform.position.y + pos.y), Quaternion.identity);
                bull.GetComponent<Bullet>().dir = -1;
                bull.GetComponent<Bullet>().lifetime = lifetime;
                bull.GetComponent<Bullet>().damage = damage;
            }
            
            cooldowntemp = cooldown;
        }
        else
        {
            cooldowntemp -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1) && Grenades > 0)
        {
            Grenades--;
            gc.Grenade();

            anim.SetTrigger("Grenade");

            if (FacingRight)
            {
                GameObject g = Instantiate(Grenade, transform.position, Quaternion.identity);
                g.GetComponent<Grenade>().dir = 1;
                g.GetComponent<Grenade>().Playerspeed = GetComponent<Rigidbody2D>().velocity;
            }
            else
            {
                GameObject g = Instantiate(Grenade, transform.position, Quaternion.identity);
                g.GetComponent<Grenade>().dir = -1;
                g.GetComponent<Grenade>().Playerspeed = GetComponent<Rigidbody2D>().velocity;
            }
        }

    }
}
