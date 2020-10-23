using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveHandler : MonoBehaviour
{

    public List<GameObject> Wave1;
    public List<GameObject> Wave2;
    public List<GameObject> Wave3;
    public List<GameObject> Wave4;
    public List<GameObject> Wave5;
    public GameObject Shop;

    public Weapon weapon;
    public RectTransform WaveInfo;
    public TextMeshProUGUI WaveInfoText;
    public float width;
    public float percent;

    public GameObject Wavetext;
    public TextMeshProUGUI Wavetexttext;

    public GameObject BossWaveIndicator;

    public Spawner spawner;

    public int Wave = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawner.EnemyWave.AddRange(Wave1);
        spawner.enemiesTotal = Wave1.Count;
        spawner.enemiesAlive = Wave1.Count;
    }

    void Update()
    {
        if(spawner.enemiesAlive == 0 && spawner.WaveStarted)
        {
            Wave += 1;
            Shop.SetActive(true);
            spawner.WaveStarted = false;
        }

        ControlUI();
    }

    // Update is called once per frame
    public void StartWave()
    {
        if (Wave == 1)
        {
            spawner.EnemyWave.AddRange(Wave1);
            spawner.enemiesTotal = Wave1.Count;
            spawner.enemiesAlive = Wave1.Count;
        }
        else if (Wave == 2)
        {
            spawner.EnemyWave.AddRange(Wave2);
            spawner.enemiesTotal = Wave2.Count;
            spawner.enemiesAlive = Wave2.Count;
        }
        else if (Wave == 3)
        {
            spawner.Multiplier = 1.0f;
            spawner.EnemyWave.AddRange(Wave3);
            spawner.enemiesTotal = Wave3.Count;
            spawner.enemiesAlive = Wave3.Count;
        }
        else if (Wave == 4)
        {
            spawner.EnemyWave.AddRange(Wave4);
            spawner.enemiesTotal = Wave4.Count;
            spawner.enemiesAlive = Wave4.Count;
        }
        else if (Wave == 5)
        {
            spawner.EnemyWave.AddRange(Wave5);
            spawner.enemiesTotal = Wave5.Count;
            spawner.enemiesAlive = Wave5.Count;
            StartCoroutine(BossWave());
        }
        Wavetext.SetActive(false);
        Wavetext.SetActive(true);

        weapon.Grenades = weapon.maxGrenades;
        spawner.numberZ = 1;
        Shop.SetActive(false);
        spawner.WaveStarted = true;
        if(Wave != 5)
            spawner.StartCoroutine(spawner.StartWave());
    }

    IEnumerator BossWave()
    {
        BossWaveIndicator.SetActive(true); 
        yield return new WaitForSeconds(2.5f);
        spawner.StartCoroutine(spawner.StartWave());
    }

    void ControlUI() 
    {
        float a = spawner.enemiesAlive;
        float b = spawner.enemiesTotal;
        WaveInfoText.text = "Wave " + Wave + " / 5";
        Wavetexttext.text = "Wave " + Wave;
        percent = a / b;
        WaveInfo.localScale = new Vector2(percent ,WaveInfo.localScale.y);
    }

    public void RestartWave()
    {
        spawner.EnemyWave.Clear();
        StartWave();
    }
}
