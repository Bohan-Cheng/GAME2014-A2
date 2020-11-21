using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CamFollow : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private float SmoothTime = 5.0f;
    [SerializeField] private bool ShouldSmooth = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (ShouldSmooth)
        {
            pos.x = Mathf.Lerp(pos.x, Target.transform.position.x, SmoothTime * Time.deltaTime);
        }
        else
        {
            pos.x = Target.transform.position.x;
        }
        transform.position = pos;
    }
}
