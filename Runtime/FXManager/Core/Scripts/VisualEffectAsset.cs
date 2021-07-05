using UnityEngine;

[CreateAssetMenu(fileName = "VisualEffectAsset", menuName = "VisualEffectAsset", order = 0)]
public class VisualEffectAsset : ScriptableObject
{
    [SerializeField] ParticleSystem prefab;
    [SerializeField] int poolSize = 1;

    [SerializeField] VisualEffectsList gameplayPools;

    public void Awake()
    {
        gameplayPools.Add(this);

    }

    public ParticleSystem Prefab { get => prefab; }
    public int PoolSize { get => poolSize; }
}

