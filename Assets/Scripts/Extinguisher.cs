using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExinguishedPerSecond = 0.1f;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100f)
        && hit.collider.TryGetComponent(out Fire fire) && Input.GetMouseButton(0)){
            Debug.Log("Extinguishing fire");
            fire.TryExtinguish(amountExinguishedPerSecond * Time.deltaTime);
        }
    }
}