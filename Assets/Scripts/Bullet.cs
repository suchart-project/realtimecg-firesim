using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // get particle system
    public ParticleSystem ps;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        if (Input.GetMouseButtonDown(0))
        {   
            ps.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ps.Stop();
        }
    }

    void SetDirection() {
        ps.transform.position = cam.transform.position + cam.transform.forward * 2;
        var shape = ps.shape;
        shape.rotation = cam.transform.rotation.eulerAngles;
    }
}
