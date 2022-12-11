using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // get particle system
    public ParticleSystem ps;
    public Camera cam;
    public GameObject buttonPlay;
    public GameObject ground;
    // public float startx;
    // public float starty;
    // public float startz;

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
        if (Input.GetMouseButtonDown(0) && buttonPlay.activeSelf == false)
        {   
            ps.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ps.Stop();
        }
        // var main = ps.main;
        // main.startLifetime = (cam.transform.position.y - ground.transform.position.y) / main.startSpeed.constant;
    }

    void SetDirection() {
        // ps.transform.position = new Vector3(cam.transform.position.x + 10 + cam.transform.forward.x * 2, cam.transform.position.y +  cam.transform.forward.y * 2, cam.transform.position.z + 10 + cam.transform.forward.z * 2);
        ps.transform.position = cam.transform.position + cam.transform.forward * 2;
        // set rotation
        // var shape = ps.shape;
        // shape.transform.rotation = cam.transform.rotation.eulerAngles;
        // Debug.Log(cam.transform.rotation.eulerAngles);
        // Debug.Log(ps.shape.rotation);
        var shape = ps.shape;
        shape.rotation = cam.transform.rotation.eulerAngles;
        // ps.transform.rotation = cam.transform.rotation.eulerAngles;
    }

    // void SetInitialPosition() {
    //     ps.transform.position = new Vector3(startx, starty, startz);
    // }
}
