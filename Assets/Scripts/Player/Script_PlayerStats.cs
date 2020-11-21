using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerStats : MonoBehaviour
{
    public int Health = 3;
    

    public void ApplyDamage()
    {
        Health--;
    }
}
