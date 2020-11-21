using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SpawnShadow : MonoBehaviour
{
    public GameObject ShadowPrefab;
    public GameObject ShadowPrefabMid;
    public GameObject ShadowPrefabLow;
    public float SpawnRate = 0.1f;
    private Script_PlayerController PC;
    private Script_PlayerStats PS;

    private void Awake()
    {
        PC = GetComponent<Script_PlayerController>();
        PS = GetComponent<Script_PlayerStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShadow", 0.1f, SpawnRate);
    }

    void SpawnShadow()
    {
        if (Mathf.Abs(PC.rigid.velocity.magnitude) > 0.1f)
        {
            if (PS.Health >= 3)
            {
                GameObject.Instantiate(ShadowPrefab, transform.position, new Quaternion());
            }
            else if(PS.Health == 2)
            {
                GameObject.Instantiate(ShadowPrefabMid, transform.position, new Quaternion());
            }
            else if (PS.Health == 1)
            {
                GameObject.Instantiate(ShadowPrefabLow, transform.position, new Quaternion());
            }
        }
    }
}
