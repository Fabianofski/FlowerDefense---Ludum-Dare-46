using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUpgrades : MonoBehaviour
{
    public int Upgrades;
    public Sprite[] sprite;
    public Image image;

    void Update()
    {
        image.sprite = sprite[Upgrades];
    }
}
