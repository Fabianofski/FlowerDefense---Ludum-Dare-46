using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public GameObject Move;
    public GameObject Jump;
    public GameObject Dash;
    public GameObject Shoot;
    public GameObject Grenade;
    public GameObject Protect;

    public GameObject Zombie;
    public GameObject transition;

    void Update()
    {
        if(Move.activeSelf)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
            Move.SetActive(false);
            Jump.SetActive(true);
            }
        }
        else if (Jump.activeSelf)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
            Jump.SetActive(false);
            Dash.SetActive(true);
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Dash.activeSelf)
        {
            Dash.SetActive(false);
            Shoot.SetActive(true);
        }
        else if (Input.GetMouseButton(0) && Shoot.activeSelf)
        {
            Shoot.SetActive(false);
            Grenade.SetActive(true);
        }
        else if (Input.GetMouseButton(1) && Grenade.activeSelf)
        {
            Grenade.SetActive(false);
            Protect.SetActive(true);
            Zombie.SetActive(true);
        }
        else if (!Zombie)
        {
            StartCoroutine(EndTutorial());
        }

    }

    IEnumerator EndTutorial()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
