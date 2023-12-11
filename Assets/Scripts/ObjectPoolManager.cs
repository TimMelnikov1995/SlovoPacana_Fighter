using System.IO;
using UnityEditor;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    #region Singelton
    private static ObjectPoolManager _instance;
    public static ObjectPoolManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<ObjectPoolManager>();

            return _instance;
        }
    }
    #endregion

    [SerializeField, HideInInspector] ObjectPool[] objectPools;

    [Header("Script update")]
    [SerializeField] string m_objectPoolEnumPath = "/Scripts/ObjectPoolEnum.cs";

    public GameObject Instantiate(int objectIndex, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject instantiatedObject;
        objectPools[objectIndex].Instantiate(position, rotation, parent, out instantiatedObject);

        return instantiatedObject;
    }

    public GameObject Instantiate(int objectIndex, Vector3 position, Quaternion rotation)
    {
        GameObject instantiatedObject;
        objectPools[objectIndex].Instantiate(position, rotation, null, out instantiatedObject);

        return instantiatedObject;
    }

    public GameObject Instantiate(int objectIndex)
    {
        GameObject instantiatedObject;
        objectPools[objectIndex].Instantiate(Vector3.zero, new Quaternion(0,0,0,0), null, out instantiatedObject);

        return instantiatedObject;
    }

    [ContextMenu("Init")]
    void Init()
    {
        objectPools = GetComponentsInChildren<ObjectPool>();

        foreach (ObjectPool OP in objectPools)
        {
            OP.CreatePool();
        }

        OnChange();
    }

    void OnChange()
    {
        if (File.Exists(Application.dataPath + m_objectPoolEnumPath))
        {
            StreamWriter sw = new StreamWriter(Application.dataPath + m_objectPoolEnumPath);
            sw.WriteLine("public enum ObjectPoolEnum");
            sw.WriteLine("{");

            foreach (ObjectPool OP in objectPools)
            {
                string _name = OP.name.Replace(' ', '_').Replace('(', '_').Replace(')', '_');
                sw.WriteLine(_name + ",");
            }

            sw.WriteLine("}");
            sw.Close();
        }
        else
            print("No File " + Application.dataPath + m_objectPoolEnumPath);
    }
}