using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    public ParticleSystem WaterLeak;
    public ParticleSystem ps;
    public float startX;
    public float startY;
    public float startZ;
    // Start is called before the first frame update
    void Start()
    {
        // ps.transform.position = WaterLeak.transform.position + 3*WaterLeak.transform.rotation + new Vector3(startX, startY, startZ);
    }

    // Update is called once per frame
    void Update()
    {
        // ps.transform.position = WaterLeak.transform.position + 3*WaterLeak.transform.rotation + new Vector3(startX, startY, startZ);
    }
}
