using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    private float[] startIntensities = new float[0];
    float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;

    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];
    private bool isLit = true;
    private bool isWind = false;
    private int counting = 0;

    private void ChangeIntensity()
    {
        for (int i=0;i<fireParticleSystems.Length;i++){
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity*startIntensities[i];

        }
    }    
    public void TryLargeStartSize(){
        for (int i=0;i<fireParticleSystems.Length;i++){
            var main = fireParticleSystems[i].main;
            main.startSize = 10; 
        }
    }
    public bool TryExtinguish(float amount){
        if(currentIntensity <= 0){
            isLit = false;
            return true;
        }
        timeLastWatered = Time.time;
        currentIntensity -= amount;
        ChangeIntensity();

        for (int i=0;i<fireParticleSystems.Length;i++){
            var startRotation = fireParticleSystems[i].startRotation;
            var main = fireParticleSystems[i].main;
            // max camera rotation is 90 degrees
            var rotationX = Camera.main.transform.rotation.x;
            var rotationY = Camera.main.transform.rotation.y;
            var rotationZ = Camera.main.transform.rotation.z;
            if (rotationX > 90){
                main.startRotationX = 90;    
            }else if(rotationX < -90){
                main.startRotationX = -90;
            }else{
                main.startRotationX = rotationX;
            }
            // if (rotationY > 90){
            //     main.startRotationY = 90;    
            // }else if(rotationY < -90){
            //     main.startRotationY = -90;
            // }else{
            //     main.startRotationY = rotationY;
            // }
            main.startRotationY = rotationY;
            if (rotationZ > 90){
                main.startRotationZ = 90;    
            }else if(rotationZ < -90){
                main.startRotationZ = -90;
            }else{
                main.startRotationZ = rotationZ;
            }
              
        }
        isWind = true;
        counting = 200;

        return false;
    }

    private void SetDefaultDirection() {
        for (int i=0;i<fireParticleSystems.Length;i++){
            var startRotation = fireParticleSystems[i].startRotation;
            var main = fireParticleSystems[i].main;
            main.startRotationX = 0;
            main.startRotationY = 0;
            main.startRotationZ = 0;  
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];
        for(int i=0;i<fireParticleSystems.Length;i++){
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;


        }
        

    }
    
    // Update is called once per frame
    void Update()
    {   
        if (isLit&&currentIntensity < 1.0f && Time.time - timeLastWatered >= regenDelay){
            currentIntensity += regenRate*Time.deltaTime;
            ChangeIntensity();
        }
        if (isWind) {
            counting--;
            if (counting == 0) {
                isWind = false;
                SetDefaultDirection();
            }
        }
    }
}
