using UnityEngine;

public class ObjectVeiwer : MonoBehaviour
{
    [SerializeField] GameObject[] m_objects;
    [SerializeField] GameObject m_camera;

    int _currentObjectIndex;

    void Start()
    {
        ViewObject(0);
    }

    public void ViewObject(int index)
    {
        if (index >= 0 && index < m_objects.Length)
        {
            for (int i = 0; i < m_objects.Length; i++)
            {
                if (i == index)
                    m_objects[i].gameObject.SetActive(true);
                else
                    m_objects[i].gameObject.SetActive(false);
            }

            m_camera.SetActive(true);
            _currentObjectIndex = index;
        }
        else
        {
            Debug.LogError("There is no object at index <<" + index + ">>");
        }
    }

    public void ViewNextObject()
    {
        _currentObjectIndex++;

        if (_currentObjectIndex >= m_objects.Length) 
        {
            _currentObjectIndex = 0;
        }

        ViewObject(_currentObjectIndex);
    }

    public void ViewPreviousObject()
    {
        _currentObjectIndex--;

        if (_currentObjectIndex < 0)
        {
            _currentObjectIndex = m_objects.Length - 1;
        }

        ViewObject(_currentObjectIndex);
    }

    public void CloseView()
    {
        m_camera.SetActive(false);

        for (int i = 0; i < m_objects.Length; i++)
        {
            m_objects[i].gameObject.SetActive(false);
        }
    }
}