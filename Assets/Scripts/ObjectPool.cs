using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjectInfo
{
    public GameObject obj;
    public Transform transform;
    public Collider colider;
    public Rigidbody body;
    public void SetActive(bool state)
    {
        obj.SetActive(state);

        if (colider != null)
        {
            colider.enabled = state;
        }

        if (body != null)
        {
            body.isKinematic = !state;
        }
    }
}

public class ObjectPool : MonoBehaviour
{
    public ObjectInfo[] objects;
    public GameObject prefab;
    public int length = 10;
    private int currentObjectInPool = 0;

    public override string ToString()
    {
        string[] names = new string[length];
        for (int i = 0; i < objects.Length; i++)
        {
            names[i] = objects[i].obj.name;
        }

        string returnStringFormat = "{" + string.Join(", ", names) + "}";

        return returnStringFormat;
    }

    public void CreateObjectPool(GameObject prefab, int length, Vector3 position)
    {
        this.prefab = prefab;
        this.length = length;
        _InitPrefabs(null, position);
    }

    public void CreateObjectPool(GameObject prefab, int length, Transform parent, Vector3 position)
    {
        this.prefab = prefab;
        this.length = length;
        _InitPrefabs(parent, position);
    }

    public void SetActive(int index, bool state)
    {
        objects[index].SetActive(state);
    }

    public void SetActiveAll(bool state)
    {
        foreach (ObjectInfo obj in objects)
        {
            obj.SetActive(state);
        }
    }

    private void _InitPrefabs(Transform parent, Vector3 position)
    {
        objects = new ObjectInfo[length];
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].obj = Instantiate(prefab);
            objects[i].transform = objects[i].obj.transform;

            if (parent != null)
                objects[i].transform.parent = parent;

            objects[i].obj.transform.position = position;
            objects[i].colider = objects[i].obj.GetComponent<Collider>();
            objects[i].body = objects[i].obj.GetComponent<Rigidbody>();

            objects[i].SetActive(false);
        }
    }

    public ObjectInfo NextInPool()
    {
        var obj = objects[currentObjectInPool];
        currentObjectInPool += 1;
        if (currentObjectInPool >= length)
        {
            currentObjectInPool = 0;
        }
        return obj;
    }

}
