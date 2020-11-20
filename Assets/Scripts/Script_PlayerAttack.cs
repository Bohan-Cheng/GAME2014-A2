using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerAttack : MonoBehaviour
{
    private int CurrentAttack = 0;
    private bool IsAttacking = false;
    public float UpSwingForce = 200.0f;
    public float DownSwingForce = 400.0f;
    public Script_PlayerController PC;

    [SerializeField] private GameObject Attack1;
    [SerializeField] private GameObject Attack2;
    [SerializeField] private GameObject Attack3;

    private bool IsSwingingUp = false;
    private bool IsSwingingDown = false;

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        if(IsSwingingUp)
        {
            PC.rigid.AddForce(new Vector2(0f, UpSwingForce));
            IsSwingingUp = false;
        }
        if(IsSwingingDown)
        {
            PC.rigid.AddForce(new Vector2(0f, -DownSwingForce));
            IsSwingingDown = false;
        }
    }

    void Attack()
    {
        if (!IsAttacking && Input.GetButtonDown("Fire1"))
        {
            IsAttacking = true;
            Invoke("DoneSlash", 0.1f);
            Invoke("DoneAttack", 0.5f);
            if (PC.InAir && PC.rigid.velocity.y >= 0)
            {
                PC.anim.SetTrigger("Attack2");
                Attack2.SetActive(true);
                IsSwingingUp = true;
            }
            else if (PC.InAir && PC.rigid.velocity.y < 0.1f)
            {
                PC.anim.SetTrigger("Attack3");
                Attack3.SetActive(true);
                IsSwingingDown = true;
            }
            else
            {
                PC.anim.SetTrigger("Attack1");
                Attack1.SetActive(true);
            }
            CurrentAttack++;
            if (CurrentAttack > 2)
                CurrentAttack = 0;
        }
    }

    void DoneSlash()
    {
        Attack1.SetActive(false);
        Attack2.SetActive(false);
        Attack3.SetActive(false);
    }
    void DoneAttack()
    {
        IsAttacking = false;
    }
}
