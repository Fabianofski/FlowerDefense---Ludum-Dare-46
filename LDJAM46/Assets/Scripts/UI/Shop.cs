using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int IndexFireRate;
    public int IndexRange;
    public int IndexDamage;
    public float[] FireRateUpgrades;
    public float[] RangeUpgrades;
    public float[] DamageUpgrades;
    public Weapon weapon;

    public Button[] button;

    public ShowUpgrades frupg;
    public ShowUpgrades rupg;
    public ShowUpgrades dmgupg;



    public void BuyFireRate()
    {
        IndexFireRate++;
        if (IndexFireRate == 1)
        {
            weapon.cooldown = FireRateUpgrades[0];
            weapon.cooldowntemp = FireRateUpgrades[0];
        }
        else if (IndexFireRate == 2)
        {
            weapon.cooldown = FireRateUpgrades[1];
            weapon.cooldowntemp = FireRateUpgrades[1];
        }
        else if (IndexFireRate == 3)
        {
            weapon.cooldown = FireRateUpgrades[2];
            weapon.cooldowntemp = FireRateUpgrades[2];
            button[0].interactable = false;
        }

    }

    public void BuyRange()
    {
        IndexRange++;
        if (IndexRange == 1)
        {
            weapon.maxGrenades = RangeUpgrades[0];
            weapon.Grenades = RangeUpgrades[0];
        }
        else if (IndexRange == 2)
        {
            weapon.maxGrenades = RangeUpgrades[1];
            weapon.Grenades = RangeUpgrades[1];
        }
        else if (IndexRange == 3)
        {
            weapon.maxGrenades = RangeUpgrades[2];
            weapon.Grenades = RangeUpgrades[2];
            button[1].interactable = false;
        }
    }

    public void BuyDamage()
    {
        IndexDamage++;
        if (IndexDamage == 1)
            weapon.damage = DamageUpgrades[0];
        else if (IndexDamage == 2)
            weapon.damage = DamageUpgrades[1];
        else if (IndexDamage == 3)
        {
            weapon.damage = DamageUpgrades[2];
            button[2].interactable = false;
        }
    }

    void Update()
    {
        frupg.Upgrades = IndexFireRate;
        rupg.Upgrades = IndexRange;
        dmgupg.Upgrades = IndexDamage;
    }
}
