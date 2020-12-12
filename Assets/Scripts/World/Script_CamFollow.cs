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
            pos.y = Mathf.Lerp(pos.y, Target.transform.position.y + 3, SmoothTime * Time.deltaTime);
        }
        else
        {
            pos.x = Target.transform.position.x;
            pos.y = Target.transform.position.y + 3;
        }
        transform.position = pos;
    }
}
