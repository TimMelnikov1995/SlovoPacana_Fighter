using UnityEngine;

public class Input_AI : MonoBehaviour
{
    void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
    }

    void OnDisable()
    {
        if(SingleUpdate.Instance != null)
        {
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
        }
    }

    void Start()
    {
        
    }



    void OnUpdate()
    {
        
    }
}
