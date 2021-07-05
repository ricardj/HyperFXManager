using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperFXManager : MonoBehaviour
{
    public static HyperFXManager get;

    Vector3 NEVERLAND_POSITION = new Vector3(-10000,-10000,-1000); //Some people doent uncheck their "Play on Awake". Thats why we spawn the particles very far away.

    [SerializeField] VisualEffectsList gameplayVisualEffects;
    [SerializeField] public Dictionary<VisualEffectAsset, Queue<ParticleSystem>> visualEffectPools;


    private void Awake()
    {
        if (get == null)
            get = this;
        else if (get != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        GenerateVisualEffectPools();
    }

    private void GenerateVisualEffectPools()
    {
        visualEffectPools = new Dictionary<VisualEffectAsset, Queue<ParticleSystem>>();
        for (int i = 0; i < gameplayVisualEffects.effectsList.Count; i++)
        {
            VisualEffectAsset visualEffect = gameplayVisualEffects.effectsList[i];
            InitializaVisualEffectPools(visualEffect);
        }
    }

    public void InitializaVisualEffectPools(VisualEffectAsset visualEffect)
    {
        Queue<ParticleSystem> visualEffectPool = new Queue<ParticleSystem>();
        for (int i = 0; i < visualEffect.PoolSize; i++)
        {
            ParticleSystem newParticle = Instantiate(visualEffect.Prefab);
            newParticle.transform.position = NEVERLAND_POSITION;
            visualEffectPool.Enqueue(newParticle);
        }

        visualEffectPools[visualEffect] = visualEffectPool;
    }

    public void SpawnEffect(VisualEffectAsset visualEffect, Vector3 position, Transform parent = null)
    {
        Queue<ParticleSystem> visualEffectPool = visualEffectPools[visualEffect];
        ParticleSystem newParticle = visualEffectPool.Dequeue();
        newParticle.transform.parent = parent;
        newParticle.transform.position = position;
        newParticle.Play();
        visualEffectPool.Enqueue(newParticle);
    }

}
