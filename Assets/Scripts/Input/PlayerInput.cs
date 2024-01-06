using System;
using UnityEngine;

public enum Keys
{
    Right,
    Left, 
    Up, 
    Down,
}

public class PlayerInput : MonoBehaviour
{
    public float horizontal_move;
    public float vertical_move;
    public bool block;
    public bool jump;
    public bool crouch;

    [SerializeField] CharacterAnimation m_character_animation;
    //[SerializeField] MovementController m_movement;

    [Header("Combo")]
    [SerializeField] KeyCombo[] m_keyCombos;
    [SerializeField] float m_comboTime = 0.1f;

    float lastInputTime;
    Keys lastKey;



    #region Singelton
    private static PlayerInput _instance;
    public static PlayerInput Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PlayerInput>();

            return _instance;
        }
    }
    #endregion





    public void SwitchPause()
    {
        //
    }

    public void InputComboKey(Keys key)
    {
        CheckKeyCombo(key);

        lastInputTime = Time.time;
        lastKey = key;
    }

    public void Block(bool do_block)
    {
        m_character_animation.SetAnimationBoolByName(AnimationTags.BLOCK_ANIMATION, do_block);

        block = do_block;
        //
    }

    public void VerticalMove(float value)
    {
        m_character_animation.VerticalMove(value);

        jump = false;
        crouch = false;

        if (value == 1f)
            jump = true; //m_movement.Jump();
        else if (value == -1f)
            crouch = true; //m_movement.Crouch();
    }

    public void HorizontalMove(float value)
    {
        horizontal_move = value;

        if (transform.rotation.eulerAngles.y < 180)
            m_character_animation.HorizontalMove(value);
        else
            m_character_animation.HorizontalMove(-value);

        //m_movement.Move(new Vector3(value, 0, 0));
    }

    void CheckKeyCombo(Keys _currentKey)
    {
        if(Time.time - lastInputTime <= m_comboTime)
        {
            foreach (KeyCombo combo in m_keyCombos)
            {
                if(combo.IsCombo(lastKey, _currentKey))
                {
                    print(combo.ComboName);
                }
            }
        }
    }



    [Serializable]
    class KeyCombo
    {
        [SerializeField] string m_comboName; // (Enum)
        [SerializeField] Keys m_firstKey;
        [SerializeField] Keys m_secondKey;

        public string ComboName => m_comboName;

        public bool IsCombo(Keys key1, Keys key2)
        {
            bool flag = false;

            if((m_firstKey == key1 && m_secondKey == key2) || (m_firstKey == key2 && m_secondKey == key1))
            {
                flag = true;
            }

            return flag;
        }
    }
}