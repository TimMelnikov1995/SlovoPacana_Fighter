using System;
using TMPro;
using UnityEngine;

public class AnimatorExtensionDemo : MonoBehaviour
{
    // ��������� ��������� � ������� �� ��������. 
    [SerializeField] Animator m_animator;

    // ��������� ��� �������� ���������� �� AnimatorController �� ������ ���������. 
    // ����������: ��� ������ AnimatorController ������ ���� ������ ���� AnimatorInfoContainer.
    [SerializeField] AnimatorInfoContainer m_animatorInfoContainer; 

    [Space]
    [SerializeField] AnimatorExtensionDemoUI m_UI;

    void Start()
    {   
        // ���������� ���������� �� AnimatorController � ���  AnimatorInfoContainer. 
        // ������� �����������, �� ����� ������ ��� ������ ��� ������ �����. 
        // ��� �� ���� ������� ���������� �� �� ���������, ������ ��� ������������� � ������� ��� ����������� � AnimatorInfoContainer ������� �������� ��� ���������. 
        m_animator.Init(m_animatorInfoContainer); 
    }

    public void ChangeAnim(string name)
    {
        m_animator.CrossFade(name, 0.2f);
    }

    public void PrintCurrentStateInfo()
    {
        // �������� �������� ������������� � ��������� �����. 
        AnimatorState curState = m_animator.GetCurrentState(m_animatorInfoContainer); 

        // ������������ ������� �� ���� ��������� ���������� � ������� State.
        string printStr = "State name = " + curState.StateName + ", Clip name = " + curState.ClipName + ", Duration = " + curState.Duration + ", Speed = " + curState.Speed;

        m_UI.PrintText.text = printStr;
        print(printStr);
    }
}

[Serializable]
class AnimatorExtensionDemoUI
{
    [SerializeField] TextMeshProUGUI m_printText;

    public TextMeshProUGUI PrintText => m_printText;
}
