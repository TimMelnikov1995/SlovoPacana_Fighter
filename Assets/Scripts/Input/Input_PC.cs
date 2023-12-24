using UnityEngine;

public class Input_PC : MonoBehaviour
{
    [SerializeField] PlayerInput m_player_input;

    [Header("Binds")]
    [SerializeField] KeyCode m_block = KeyCode.Space;
    [SerializeField] KeyCode m_pause = KeyCode.Escape;
    [Space]
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

        if (Input.GetKeyDown(m_punch_1))
            m_player_input.InputComboKey(Keys.Up);

        if (Input.GetKeyDown(m_punch_2))
            m_player_input.InputComboKey(Keys.Down);

        if (Input.GetKeyDown(m_kick_1))
            m_player_input.InputComboKey(Keys.Left);

        if (Input.GetKeyDown(m_kick_2))
            m_player_input.InputComboKey(Keys.Right);

        m_player_input.Block(Input.GetKey(m_block));

        m_player_input.HorizontalMove(Input.GetAxisRaw(AxisTags.HORIZONTAL_AXIS));
        m_player_input.VerticalMove(Input.GetAxisRaw(AxisTags.VERTICAL_AXIS));
    }
}
