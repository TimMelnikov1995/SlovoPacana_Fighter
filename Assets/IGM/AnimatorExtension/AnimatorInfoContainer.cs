using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animator Info Container", menuName = "ScriptableObjects/Animator Info Container", order = 1)]
public class AnimatorInfoContainer : ScriptableObject
{
    public List<AnimatorState> AnimatorStates = new();

    public void Clear()
    {
        AnimatorStates.Clear();
    }
}

[Serializable]
public class AnimatorState
{
    public string StateName;
    public string ClipName;
    public float Duration;
    public float Speed;
}