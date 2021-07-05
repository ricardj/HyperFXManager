using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VisualEffectPools", menuName = "VisualEffectPools", order = 0)]
public class VisualEffectsList : ScriptableObject
{
    public List<VisualEffectAsset> effectsList;

    public void Add(VisualEffectAsset visualEffect)
    {
        effectsList.Add(visualEffect);
    }


}
