using UnityEngine;

public class Input_PC : MonoBehaviour
{
    [SerializeField] PlayerInput m_playerInput;

    [SerializeField] KeyCode m_right = KeyCode.D;

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
        {
            m_playerInput.InputRight();
        }
    }
}
