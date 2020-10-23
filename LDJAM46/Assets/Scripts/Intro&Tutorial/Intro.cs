using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public AudioSource flashsound;
    public GameObject Transition;
    public float flashtime;
    public float endtime;
    public int buildindex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Handler());
    }


    IEnumerator Handler()
    {
        yield return new WaitForSeconds(flashtime);
        flashsound.Play();
        yield return new WaitForSeconds(endtime);
        Transition.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(buildindex);
    }

}
