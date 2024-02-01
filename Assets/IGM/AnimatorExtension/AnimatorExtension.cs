using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public static class AnimatorExtension
{
    public static AnimationClip GetAnimationClipByName(this Animator animator, string name)
    {
        if (!animator)
            return null;

        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            if (animator.runtimeAnimatorController.animationClips[i].name == name)
                return animator.runtimeAnimatorController.animationClips[i];
        }

        return null;
    }

    public static AnimatorState GetCurrentState(this Animator animator, AnimatorInfoContainer animatorInfoContainer, int layer = 0)
    {
        if (!animator || !animatorInfoContainer)
            return null;

        foreach(AnimatorState state in animatorInfoContainer.AnimatorStates)
        {
            if (animator.GetCurrentAnimatorStateInfo(layer).IsName(state.StateName))
            {
                return state;
            }
        }

        return null;
    }



#if UNITY_EDITOR
    public static void Init(this Animator animator, AnimatorInfoContainer animatorInfoContainer)
    {
        if (!animator || !animatorInfoContainer)
            return;

        animatorInfoContainer.Clear();

        List<UnityEditor.Animations.AnimatorState> allAnimatorStates = GetAllAnimatorStates(animator);
        
        foreach (UnityEditor.Animations.AnimatorState state in allAnimatorStates)
        {
            AnimatorState newState = new();

            newState.StateName = state.name;
            newState.ClipName = state.motion.name;
            newState.Duration = state.motion.averageDuration;
            newState.Speed = state.speed;

            animatorInfoContainer.AnimatorStates.Add(newState);
        }
    }

    static List<UnityEditor.Animations.AnimatorState> GetAllAnimatorStates(this Animator animator)
    {
        if (!animator)
            return null;

        AnimatorController ac = animator.runtimeAnimatorController as AnimatorController;
        List<UnityEditor.Animations.AnimatorState> allStates = new();

        for (int i = 0; i < ac.layers.Length; i++)
        {
            for (int j = 0; j < ac.layers[i].stateMachine.states.Length; j++)
            {
                allStates.Add(ac.layers[i].stateMachine.states[j].state);
            }
        }

        return allStates;
    }
#endif

}