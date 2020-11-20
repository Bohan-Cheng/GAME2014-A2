using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    public int Health = 3;
    [SerializeField] private bool IsAlive = true;

    public void ApplyDamage(int Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            GetComponent<Animator>().SetBool("IsAlive", IsAlive = false);
            Invoke("CleanBody", 10.0f);
        }
    }

    void CleanBody()
    {
        Destroy(gameObject);
    }
}
