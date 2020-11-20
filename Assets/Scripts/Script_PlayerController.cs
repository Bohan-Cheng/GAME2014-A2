using UnityEngine;
using UnityEngine.Events;

public class Script_PlayerController : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400.0f;
	[SerializeField] private float MoveSpeed = 20.0f;
	[SerializeField] private float MoveFriction = 0.5f;
	[SerializeField] private float MaxMoveSpeed = 5.0f;
	[SerializeField] private LayerMask GroundLayer;

	public Rigidbody2D rigid;
	public Animator anim;
	private bool FacingRight = true;
	public bool InAir = true;
	public bool IsAlive = true;
	private bool IsJumping = false;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

    private void Update()
    {
        if(!IsJumping && Input.GetButtonDown("Jump"))
        {
			IsJumping = true;
        }
    }

    void FixedUpdate()
	{
		CheckForGround();
		Move();
	}

	public void Move()
	{
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
		anim.SetFloat("Speed", Mathf.Abs(movement.x));
		rigid.AddForce(movement * MoveSpeed);
		rigid.velocity = new Vector2(rigid.velocity.x * MoveFriction, rigid.velocity.y);

		if (Input.GetAxis("Horizontal") > 0 && !FacingRight) { Flip(); }
		else if (Input.GetAxis("Horizontal") < 0 && FacingRight) { Flip(); }

		if (!InAir && IsJumping)
		{
			rigid.AddForce(new Vector2(0f, JumpForce));
			IsJumping = false;
		}
		rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -MaxMoveSpeed, MaxMoveSpeed), rigid.velocity.y);
	}

	private void Flip()
	{
		FacingRight = !FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void CheckForGround()
    {
		RaycastHit2D hit;
		if (hit = Physics2D.CircleCast(transform.position, 0.2f, -Vector2.up, 0.1f, GroundLayer))
		{
			InAir = false;
		}
		else
        {
			InAir = true;
        }
		anim.SetFloat("YSpeed", rigid.velocity.y);
		anim.SetBool("InAir", InAir);
	}
}