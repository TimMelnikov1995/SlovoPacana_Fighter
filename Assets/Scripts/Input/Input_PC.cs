using UnityEngine;

public class Input_PC : InputVariant
{
    [Header("Binds")]
    [SerializeField] KeyCode m_block = KeyCode.Space;
    [SerializeField] KeyCode m_pause = KeyCode.Escape;
    [Space]
    [SerializeField] KeyCode m_punch_1 = KeyCode.UpArrow;
    [SerializeField] KeyCode m_punch_2 = KeyCode.DownArrow;
    [SerializeField] KeyCode m_kick_1 = KeyCode.LeftArrow;
    [SerializeField] KeyCode m_kick_2 = KeyCode.RightArrow;



    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(m_pause))
            m_input_script.SwitchPause();

        if (Input.GetKeyDown(m_punch_1))
            m_input_script.InputComboKey(Keys.Up);

        if (Input.GetKeyDown(m_punch_2))
            m_input_script.InputComboKey(Keys.Down);

        if (Input.GetKeyDown(m_kick_1))
            m_input_script.InputComboKey(Keys.Left);

        if (Input.GetKeyDown(m_kick_2))
            m_input_script.InputComboKey(Keys.Right);

        m_input_script.Block(Input.GetKey(m_block));

        m_input_script.HorizontalMove(Input.GetAxisRaw(AxisTags.HORIZONTAL_AXIS));
        m_input_script.VerticalMove(Input.GetAxisRaw(AxisTags.VERTICAL_AXIS));
    }
}
