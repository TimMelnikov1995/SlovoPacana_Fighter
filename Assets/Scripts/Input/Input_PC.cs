using UnityEngine;

public class Input_PC : MonoBehaviour
{
    [SerializeField] PlayerInput m_player_input;

    [SerializeField] KeyCode m_up = KeyCode.W;
    [SerializeField] KeyCode m_down = KeyCode.S;
    [SerializeField] KeyCode m_left = KeyCode.A;
    [SerializeField] KeyCode m_right = KeyCode.D;

    [SerializeField] KeyCode m_block = KeyCode.Space;
    [SerializeField] KeyCode m_pause = KeyCode.Escape;

    [SerializeField] KeyCode m_punch_1 = KeyCode.UpArrow;
    [SerializeField] KeyCode m_punch_2 = KeyCode.DownArrow;
    [SerializeField] KeyCode m_kick_1 = KeyCode.LeftArrow;
    [SerializeField] KeyCode m_kick_2 = KeyCode.RightArrow;



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
        if (Input.GetKeyDown(m_pause))
            m_player_input.SwitchPause();
        else
        {
            if (Input.GetKeyDown(m_punch_1))
                m_player_input.InputComboKey(Keys.Up);
            else if (Input.GetKeyDown(m_punch_2))
                m_player_input.InputComboKey(Keys.Down);
            else if (Input.GetKeyDown(m_kick_1))
                m_player_input.InputComboKey(Keys.Left);
            else if (Input.GetKeyDown(m_kick_2))
                m_player_input.InputComboKey(Keys.Right);
            else if (Input.GetKey(m_up))
                m_player_input.Jump(true);
            else if (Input.GetKey(m_block))
                m_player_input.Block(true);
            else if (Input.GetKey(m_down))
                m_player_input.Crouch(true);
            else if (Input.GetKey(m_right))
                m_player_input.Move(1);
            else if (Input.GetKey(m_left))
                m_player_input.Move(-1);
            else
            {
                m_player_input.Jump(false);
                m_player_input.Block(false);
                m_player_input.Crouch(false);
                m_player_input.Move(0);
            }
        }
    }
}
