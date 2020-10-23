using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCooldown : MonoBehaviour
{
    private float height;
    private float percent;

    // Start is called before the first frame update
    void Start()
    {
        height = gameObject.GetComponent<RectTransform>().localScale.y;
    }

    public void Grenade()
    {
        percent = 0;
    }

    void Update()
    {
        percent += Time.deltaTime * 4;
        if (percent > 1)
            percent = 1;
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(height, height * percent);
    }
}
