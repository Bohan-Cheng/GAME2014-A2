using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Shadow : MonoBehaviour
{
    // Start is called before the first frame update

    void DestroyShadow()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        Vector3 rot = Random.rotation.eulerAngles;
        rot.x = rot.y = 0.0f;
        transform.Rotate(rot);

        Invoke("DestroyShadow", 0.5f);
    }

    private void Update()
    {
        Vector3 sc = transform.localScale;
        sc.x -= 2.0f * Time.deltaTime;
        sc.y -= 2.0f * Time.deltaTime;
        transform.localScale = sc;
    }
}
