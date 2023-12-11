using UnityEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject m_prefab;
    [SerializeField] int m_count;
    [SerializeField, HideInInspector] GameObject[] objects;

    public void SetChilInactive()
    {
        foreach(GameObject GO in objects)
        {
            GO.SetActive(false);
        }
    }

    public void Instantiate(Vector3 position, Quaternion rotation, Transform parent, out GameObject InstantiatedObject)
    {
        if (objects.Length > 0)
        {
            int objectIndex = FindDiactiveObject();

            if (objectIndex != -1)
            {
                objects[objectIndex].transform.position = position;
                objects[objectIndex].transform.rotation = rotation;
                objects[objectIndex].transform.parent = parent;
                objects[objectIndex].SetActive(true);

                InstantiatedObject = objects[objectIndex];
            }
            else
            {
                InstantiatedObject = null;
            }
        }
        else { InstantiatedObject = null; }
    }

    int FindDiactiveObject()
    {
        int objectIndex = 0;

        for(int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeSelf == false)
            {
                objectIndex = i;
                break;
            }

            if (i == objects.Length - 1 && objects[i].activeSelf == true)
            {
                objectIndex = -1;
            }
        }

        return objectIndex;
    }

    public void CreatePool()
    {
        Clear();

        for (int i = 0; i < m_count; i++)
        {
#if UNITY_EDITOR
            PrefabUtility.InstantiatePrefab(m_prefab, transform);
#endif
        }

        FindAllChildrenObjects();
        SetChilInactive();
    }

    void FindAllChildrenObjects()
    {
        objects = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            objects[i] = transform.GetChild(i).gameObject;
        }
    }

    void Clear()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
             DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}