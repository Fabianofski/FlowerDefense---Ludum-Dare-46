using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public Transform Slider;
    public GameObject LoseScreen;
    private bool GameEnd;
    public Spawner spawner;
    public GameObject Player;
    public WaveHandler wh;
    
    void Update()
    {
        if (Health < 0)
            Lose();
        Slider.localScale = new Vector2 (Health / MaxHealth, Slider.localScale.y);

        if(GameEnd && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("r");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            Player.GetComponent<Weapon>().enabled = true;
            spawner.enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = true;
            GameEnd = false;
            Health = MaxHealth;
            LoseScreen.SetActive(false);
            wh.RestartWave();
        }
    }

    void Lose()
    {
        Player.GetComponent<Weapon>().enabled = false;
        spawner.enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        GameEnd = true;
        Health = 0;
        LoseScreen.SetActive(true);
    }
}
