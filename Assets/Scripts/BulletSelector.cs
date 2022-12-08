using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSelector : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public ParticleSystem ps;
    private Color psColor;
    private bool activeBullet1 = false;
    private bool activeBullet2 = false;
    private bool activeBullet3 = false;
    // Start is called before the first frame update
    void Start()
    {
        psColor = ps.main.startColor.color;
        // change color of image bullet1
        bullet1.GetComponent<Image>().color = Color.red;
        activeBullet1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if user press tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeBullet1)
            {
                bullet1.GetComponent<Image>().color = Color.white;
                bullet2.GetComponent<Image>().color = Color.red;
                bullet3.GetComponent<Image>().color = Color.white;
                SetParticleColor(Color.green);
                activeBullet1 = false;
                activeBullet2 = true;
                activeBullet3 = false;
            }
            else if (activeBullet2)
            {
                bullet1.GetComponent<Image>().color = Color.white;
                bullet2.GetComponent<Image>().color = Color.white;
                bullet3.GetComponent<Image>().color = Color.red;
                SetParticleColor(Color.yellow);
                activeBullet1 = false;
                activeBullet2 = false;
                activeBullet3 = true;
            }
            else if (activeBullet3)
            {
                bullet1.GetComponent<Image>().color = Color.red;
                bullet2.GetComponent<Image>().color = Color.white;
                bullet3.GetComponent<Image>().color = Color.white;
                SetParticleColor(psColor);
                activeBullet1 = true;
                activeBullet2 = false;
                activeBullet3 = false;
            }
        }
    }

    private void SetParticleColor(Color color)
    {
        var main = ps.main;
        main.startColor = color;
    }
}