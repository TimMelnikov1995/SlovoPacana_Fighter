using System;
using TMPro;
using UnityEngine;

public class AnimatorExtensionDemo : MonoBehaviour
{
    // Компонент аниматора с которым мы работаем. 
    [SerializeField] Animator m_animator;

    // Контейнер для хранения информации об AnimatorController из нашего аниматора. 
    // ПРИМЕЧАНИЕ: Для кажого AnimatorController должен быть создан свой AnimatorInfoContainer.
    [SerializeField] AnimatorInfoContainer m_animatorInfoContainer; 

    [Space]
    [SerializeField] AnimatorExtensionDemoUI m_UI;

    void Start()
    {   
        // Записываем информацию из AnimatorController в наш  AnimatorInfoContainer. 
        // Процесс прожорливый, по этому делаем это только при старте сцены. 
        // Так же этот процесс недоступен не из редактора, однако при инициализации в эдиторе все сохраняется в AnimatorInfoContainer который работает вне редактора. 
        m_animator.Init(m_animatorInfoContainer); 
    }

    public void ChangeAnim(string name)
    {
        m_animator.CrossFade(name, 0.2f);
    }

    public void PrintCurrentStateInfo()
    {
        // Получаем анимацию проигрываемою в настоящее время. 
        AnimatorState curState = m_animator.GetCurrentState(m_animatorInfoContainer); 

        // Демонстрация доступа ко всей доступной информации о текущей State.
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
