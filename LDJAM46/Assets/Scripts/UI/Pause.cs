using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf)
            {
                Time.timeScale = 1;
                if (GameObject.FindWithTag("Player"))
                    GameObject.FindWithTag("Player").GetComponent<Weapon>().enabled = true;
            }
            else
            {
                Time.timeScale = 0;
                if(GameObject.FindWithTag("Player"))
                    GameObject.FindWithTag("Player").GetComponent<Weapon>().enabled = false;
            }
            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        if (GameObject.FindWithTag("Player"))
            GameObject.FindWithTag("Player").GetComponent<Weapon>().enabled = true;
        PauseMenu.SetActive(!PauseMenu.activeSelf);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
