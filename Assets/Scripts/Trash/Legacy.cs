using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Legacy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    List<AnimatorState> _state = new();

    void Some()
	{
        /*
        AnimatorController ac = _animator.runtimeAnimatorController as AnimatorController;

        //////////////////////////////////////////////////////////////////////////////////

        AnimatorState _nuzhnyiState;

        for(int i = 0; i < ac.layers.Length; i++)
            for (int j = 0; j < ac.layers[i].stateMachine.states.Length; j++)
                _nuzhnyiState = ac.layers[i].stateMachine.states[j].state;

        //////////////////////////////////////////////////////////////////////////////////

        AnimatorControllerLayer[] layers = ac.layers;

        foreach (AnimatorControllerLayer layer in layers)
        {
            ChildAnimatorState[] states = layer.stateMachine.states;

            foreach (ChildAnimatorState child in states)
            {
                _state.Add(child.state);
            }
        }
        */
    }
}
