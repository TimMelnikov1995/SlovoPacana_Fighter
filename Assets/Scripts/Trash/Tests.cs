using System.Collections;
using UnityEngine;

public class Tests : MonoBehaviour
{
    [SerializeField] ObjectPoolEnum m_vfx;

    #region Style
    [SerializeField] float m_fl;
    private float fl;
    public float Fl;
    void AttributeStyle(float _fl) { }
    #endregion

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

    void Start()
    {
        
    }

    void OnUpdate()
    {
        
    }

    [ContextMenu("Vfx")]
    void Vfx()
    {
        ObjectPoolManager.Instance.Instantiate((int)m_vfx);
    }
}

public class Test
{
    void Init()
    {
        SingleUpdate.Instance.startCoroutine(TestEnumerator());
    }

    IEnumerator TestEnumerator()
    {
        yield return new WaitForSeconds(1);
    }
}