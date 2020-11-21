using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    public int Health = 3;
    public float CleanTime = 10.0f;
    [SerializeField] private bool IsAlive = true;

    public void ApplyDamage(int Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            GetComponent<Animator>().SetBool("IsAlive", IsAlive = false);
            Invoke("CleanBody", CleanTime);
        }
    }

    void CleanBody()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsAlive && collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<Script_PlayerStats>().ApplyDamage();
        }
    }
}
