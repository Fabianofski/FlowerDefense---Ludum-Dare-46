using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float hp;
    public Spawner spawner;
    private Animator anim;
    private bool end;
    public Color damagecolor;
    public GameObject Particle;

    public bool Boss;
    public GameObject ParticleBoss;
    public GameObject Transition;
    private float maxhp;

    public AudioSource explodeSound;

    void Start()
    {
        maxhp = hp;
        if (Boss)
            GameObject.FindWithTag("BossHealth").GetComponent<Animator>().SetTrigger("Boss");
        if (GameObject.FindWithTag("Progress") && Boss)
            GameObject.FindWithTag("Progress").SetActive(false);

        if (GameObject.FindWithTag("Transition"))
            Transition = GameObject.FindWithTag("Transition");
        anim = GetComponent<Animator>();
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
    }

    void Update()
    {
        if(hp <= 0 && !end )
        {

            
            if (!Boss)
            {

                if (Particle)
                    Destroy(Particle);
                transform.Rotate(transform.eulerAngles.x, transform.eulerAngles.x, 90, Space.World);
                
                GetComponent<SimpleMovement>().enabled = false;
                GetComponent<AttackBase>().enabled = false;
                gameObject.layer = 12;
                anim.SetTrigger("Die");
                if (spawner)
                    spawner.enemiesAlive -= 1;
            }
            else
            {
                explodeSound.Play();
                Instantiate(ParticleBoss, transform.position, Quaternion.identity);
                GetComponent<BossMovement>().enabled = false;
                StartCoroutine(End());
            }
            end = true;
            Destroy(gameObject, 3f);
        }

        if (Boss)
        {
            if (hp < 0)
                hp = 0;
            GameObject.FindWithTag("BossHealthFill").GetComponent<RectTransform>().localScale = new Vector2(hp / maxhp, 1);
        }
    }

    public IEnumerator End()
    {
        Transition.GetComponent<Animator>().enabled = true ;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator Pulse()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.Lerp(color, damagecolor, 0.5f);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
