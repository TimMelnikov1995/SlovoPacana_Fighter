using UnityEngine;

public class Input_PC : MonoBehaviour
{
    [SerializeField] PlayerInput m_playerInput;

    [SerializeField] KeyCode m_up = KeyCode.W;
    [SerializeField] KeyCode m_down = KeyCode.S;
    [SerializeField] KeyCode m_left = KeyCode.A;
    [SerializeField] KeyCode m_right = KeyCode.D;

    [SerializeField] KeyCode m_combo_key_1 = KeyCode.UpArrow;
    [SerializeField] KeyCode m_combo_key_2 = KeyCode.DownArrow;
    [SerializeField] KeyCode m_combo_key_3 = KeyCode.LeftArrow;
    [SerializeField] KeyCode m_combo_key_4 = KeyCode.RightArrow;
    [SerializeField] KeyCode m_combo_key_5 = KeyCode.M;

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
        if (Input.GetKeyDown(m_right))
            m_playerInput.InputMovement(1);
        else if (Input.GetKeyDown(m_left))
            m_playerInput.InputMovement(-1);
        else if (true)
            m_playerInput.InputComboKey(Keys.Right);
        else if (true)
            m_playerInput.InputComboKey(Keys.Left);
        else if (Input.GetKeyDown(m_up))
            m_playerInput.InputComboKey(Keys.Up);
        else if (Input.GetKeyDown(m_down))
            m_playerInput.InputComboKey(Keys.Down);
    }
}
