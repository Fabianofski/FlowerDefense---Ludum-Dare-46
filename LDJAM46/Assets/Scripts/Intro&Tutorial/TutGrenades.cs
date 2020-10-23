using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutGrenades : MonoBehaviour
{

    private Weapon weapon;

    void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if(weapon.Grenades < 1)
        {
            weapon.Grenades = 3;
        }
    }



}
