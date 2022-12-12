using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // get particle system
    public GameObject buttonPlay;
    public GameObject gun;
    public float positionX;
    public float positionY;
    public float positionZ;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public GameObject projectilePrefab3;
    private ParticleSystem ps;
    private int activeProjectileType;
    [SerializeField] private float amountExinguishedPerSecond = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        selectProjectile(1);
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps != null)
        {
            if (Input.GetMouseButtonDown(0) && buttonPlay.activeSelf == false)
            {   
                ps.Play();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ps.Stop();
            }
        }
        if(activeProjectileType == 1){
            amountExinguishedPerSecond = 1f;
        }else if(activeProjectileType== 2){
            amountExinguishedPerSecond = 0.5f;
        }else if(activeProjectileType == 3){
            amountExinguishedPerSecond = 0.1f;
        }
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100f)
        && hit.collider.TryGetComponent(out Fire fire) && Input.GetMouseButton(0)){
            Debug.Log("Extinguishing fire");
            fire.TryExtinguish(amountExinguishedPerSecond * Time.deltaTime);
        }

    }
    


    // Delete existing child and instantiate new projectile
    public void selectProjectile(int slot)
    {
        ps = null;
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject projectileEmitter = null;
        if (slot == 1)
        {
            projectileEmitter = Instantiate(projectilePrefab1, this.transform);
        }
        else if (slot == 2)
        {
            projectileEmitter = Instantiate(projectilePrefab2, this.transform);
        }
        else if (slot == 3)
        {
            projectileEmitter = Instantiate(projectilePrefab3, this.transform);
        }
        projectileEmitter.transform.position = gun.transform.position + new Vector3(positionX, positionY, positionZ);
        ps = projectileEmitter.GetComponent<ParticleSystem>();
        ps.Stop();
        activeProjectileType = slot;
    }

    public int getActiveProjectileType()
    {
        return activeProjectileType;
    }
}

// ps.transform.position = gun.transform.position + new Vector3(positionX, positionY, positionZ);
//         var shape = ps.shape;
//         shape.rotation = cam.transform.rotation.eulerAngles;
//         // Debug.Log(shape.rotation);