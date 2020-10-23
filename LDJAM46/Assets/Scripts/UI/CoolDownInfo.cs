using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownInfo : MonoBehaviour
{
    public Weapon weapon;
    private float height;
    private float percent;

    // Start is called before the first frame update
    void Start()
    {
        height = gameObject.GetComponent<RectTransform>().localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        percent = 1 - weapon.cooldowntemp / weapon.cooldown;
        if (percent > 1)
            percent = 1;
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(height, height * percent);
    }
}
