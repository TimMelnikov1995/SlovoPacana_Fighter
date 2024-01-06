using UnityEngine;

public class InputVariant : MonoBehaviour
{
    [SerializeField] protected PlayerInput m_input_script;

    

    protected void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
    }

    protected void OnDisable()
    {
        if (SingleUpdate.Instance != null)
        {
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
        }
    }



    protected virtual void OnUpdate()
    {

    }
}