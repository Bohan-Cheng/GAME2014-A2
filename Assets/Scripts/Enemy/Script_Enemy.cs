using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    public int Health = 3;
    public float CleanTime = 10.0f;
    [SerializeField] private bool IsAlive = true;
    [SerializeField] private float MaxMoveSpeed = 5.0f;
    [SerializeField] private float patrolTime = 3.0f;
    [SerializeField] bool MoveRight = false;
    [SerializeField] float Fov = 5.0f;
    [SerializeField] float AttackFov = 3.0f;
    private Rigidbody2D rigid;
    private GameObject player;
    private Animator anim;

    public void ApplyDamage(int Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            GetComponent<Animator>().SetBool("IsAlive", IsAlive = false);
            tag = "Dead";
            Invoke("CleanBody", CleanTime);
        }
    }

    void CleanBody()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        if(MoveRight)
        {
            Invoke("GoLeft", patrolTime);
        }
        else
        {
            Invoke("GoRight", patrolTime);
        }
    }

    void GoLeft()
    {
        if (!PlayerInRange())
        {
            MoveRight = false;
            Invoke("GoRight", patrolTime);
        }
    }

    void GoRight()
    {
        if (!PlayerInRange())
        {
            MoveRight = true;
            
            Invoke("GoLeft", patrolTime);
        }
    }

    private void Update()
    {
        if (IsAlive)
        {
            anim.SetBool("Attack", PlayerInAttackRange());
            if (!PlayerInAttackRange())
            {
                Move();
            }
            if (PlayerInRange())
            {
                if (player.transform.position.x < transform.position.x)
                {
                    MoveRight = false;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    MoveRight = true;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }

    void Move()
    {
        if (MoveRight)
        {
            rigid.AddForce(transform.right * 5);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            rigid.AddForce(-transform.right * 5);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -MaxMoveSpeed, MaxMoveSpeed), rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsAlive && collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<Script_PlayerStats>().ApplyDamage();
        }
    }

    bool PlayerInRange()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= Fov)
        {
            return true;
        }
        return false;
    }


    bool PlayerInAttackRange()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= AttackFov)
        {
            return true;
        }
        return false;
    }
}
