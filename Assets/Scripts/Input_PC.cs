using UnityEngine;

public class Input_PC : MonoBehaviour
{
    [SerializeField] PlayerInput m_playerInput;

    [SerializeField] KeyCode m_right = KeyCode.D;
    [SerializeField] KeyCode m_left = KeyCode.A;
    [SerializeField] KeyCode m_up = KeyCode.W;
    [SerializeField] KeyCode m_down = KeyCode.S;

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
            m_playerInput.InputKey(Keys.Right);

        if (Input.GetKeyDown(m_left))
            m_playerInput.InputKey(Keys.Left);

        if (Input.GetKeyDown(m_up))
            m_playerInput.InputKey(Keys.Up);

        if (Input.GetKeyDown(m_down))
            m_playerInput.InputKey(Keys.Down);
    }
}
