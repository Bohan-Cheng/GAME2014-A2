using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BGScroll : MonoBehaviour
{
    private Script_PlayerController PC;
    [SerializeField] private float ScrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<Script_PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x += -PC.rigid.velocity.x * ScrollSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
