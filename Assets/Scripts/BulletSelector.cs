using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSelector : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject imgBullet1;
    public GameObject imgBullet2;
    public GameObject imgBullet3;
    public GameObject buttonPlay;
    public ParticleSystem ps;
    private Color psColor;
    private bool activeBullet1 = false;
    private bool activeBullet2 = false;
    private bool activeBullet3 = false;
    // Start is called before the first frame update
    void Start()
    {
        bullet1.SetActive(false);
        bullet2.SetActive(false);
        bullet3.SetActive(false);
        imgBullet1.SetActive(false);
        imgBullet2.SetActive(false);
        imgBullet3.SetActive(false);
        psColor = ps.main.startColor.color;
        // change color of image bullet1
        bullet1.GetComponent<Image>().color = Color.gray;
        activeBullet1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPlay.activeSelf == false)
        {
            bullet1.SetActive(true);
            bullet2.SetActive(true);
            bullet3.SetActive(true);
            imgBullet1.SetActive(true);
            imgBullet2.SetActive(true);
            imgBullet3.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (activeBullet1)
                {
                    bullet1.GetComponent<Image>().color = Color.white;
                    bullet2.GetComponent<Image>().color = Color.gray;
                    bullet3.GetComponent<Image>().color = Color.white;
                    SetParticleColor(Color.cyan);
                    activeBullet1 = false;
                    activeBullet2 = true;
                    activeBullet3 = false;
                }
                else if (activeBullet2)
                {
                    bullet1.GetComponent<Image>().color = Color.white;
                    bullet2.GetComponent<Image>().color = Color.white;
                    bullet3.GetComponent<Image>().color = Color.gray;
                    SetParticleColor(Color.yellow);
                    activeBullet1 = false;
                    activeBullet2 = false;
                    activeBullet3 = true;
                }
                else if (activeBullet3)
                {
                    bullet1.GetComponent<Image>().color = Color.gray;
                    bullet2.GetComponent<Image>().color = Color.white;
                    bullet3.GetComponent<Image>().color = Color.white;
                    SetParticleColor(psColor);
                    activeBullet1 = true;
                    activeBullet2 = false;
                    activeBullet3 = false;
                }
            }
        }
        else
        {
            bullet1.SetActive(false);
            bullet2.SetActive(false);
            bullet3.SetActive(false);
            imgBullet1.SetActive(false);
            imgBullet2.SetActive(false);
            imgBullet3.SetActive(false);
        }
    }

    private void SetParticleColor(Color color)
    {
        var main = ps.main;
        main.startColor = color;
    }
}