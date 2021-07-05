using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRandomExplosion : MonoBehaviour
{
    [SerializeField] VisualEffectAsset visualEffect;

    float randomExplosionCounter = 0;
    float randomExplosionPeriod = 2f;



    public void Update()
    {
        randomExplosionCounter += Time.deltaTime;
        if(randomExplosionCounter > randomExplosionPeriod)
        {
            randomExplosionCounter = 0;
            HyperFXManager.get.SpawnEffect(visualEffect, transform.position);
        }
    }

  
}
