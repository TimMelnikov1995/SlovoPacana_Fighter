using System.Collections;
using UnityEngine;

public class SingleUpdate : MonoBehaviour
{
    public delegate void updateDelegate();
    public updateDelegate UpdateDelegate;

    public delegate void lateUpdateDelegate();
    public lateUpdateDelegate LateUpdateDelegate;

    public delegate void optimizedUpdateDelegate();
    public optimizedUpdateDelegate OptimizedUpdateDelegate;

    [SerializeField] float m_optimizedUpdateTime = 0.1f;



    #region Singelton
    private static SingleUpdate _instance;
    public static SingleUpdate Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<SingleUpdate>();

            return _instance;
        }
    }
    #endregion



    void Start()
    {
        StartCoroutine(OptimizedUpdate());
    }

    void Update()
    {
        UpdateDelegate?.Invoke();
    }

    void LateUpdate()
    {
        LateUpdateDelegate?.Invoke();
    }



    IEnumerator OptimizedUpdate()
    {
        yield return new WaitForSeconds(m_optimizedUpdateTime);

        OptimizedUpdateDelegate?.Invoke();

        StartCoroutine(OptimizedUpdate());
    }

    public void startCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }

    public void stopCoroutine(IEnumerator enumerator)
    {
        StopCoroutine(enumerator);
    }
}