using System.Collections;
using UnityEngine;

public class Tests : MonoBehaviour
{
    [SerializeField] ObjectPoolEnum m_vfx;

    #region Style
    [SerializeField] float m_fl_num;
    private float _flNum;
    public float Fl_Num;
    void AttributeStyle(float flNum)
    {
        float fl_num;
    }

    // Нейминг:
    // System - скрипт, отвечающий за работу нескольких скриптов
    // Manager - скрипт, отвечающий за работу нескольких GameObject'ов или внешних объектов
    // Controller - скрипт, отвечающий за работу конкретного GameObject'а и его дочерних объектов
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