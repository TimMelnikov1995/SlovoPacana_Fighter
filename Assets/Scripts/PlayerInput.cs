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
    [SerializeField] KeyCode m_left = KeyCode.A;
    [SerializeField] KeyCode m_up = KeyCode.W;
    [SerializeField] KeyCode m_down = KeyCode.S;

    [Header("Combo")]
    [SerializeField] KeyCombo[] m_keyCombos;
    [SerializeField] float m_comboTime = 0.1f;

    float lastInputTime;
    Keys lastKey;

    private void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
    }

    private void OnDisable()
    {
        if (SingleUpdate.Instance != null)
        {
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
        }
    }

    void OnUpdate()
    {
        if (Input.GetKeyDown(m_left))
        {
            CheckKeyCombo(Keys.Left);

            lastInputTime = Time.time;
            lastKey = Keys.Left;
        }

        if (Input.GetKeyDown(m_up))
        {
            CheckKeyCombo(Keys.Up);

            lastInputTime = Time.time;
            lastKey = Keys.Up;
        }

        if (Input.GetKeyDown(m_down))
        {
            CheckKeyCombo(Keys.Down);

            lastInputTime = Time.time;
            lastKey = Keys.Down;
        }
    }

    public void InputRight()
    {
        CheckKeyCombo(Keys.Right);

        lastInputTime = Time.time;
        lastKey = Keys.Right;
    }

    void CheckKeyCombo(Keys _currentKey)
    {
        if(Time.time - lastInputTime <= m_comboTime)
        {
            foreach (KeyCombo combo in m_keyCombos)
            {
                if(combo.IsCombo(_currentKey, lastKey))
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