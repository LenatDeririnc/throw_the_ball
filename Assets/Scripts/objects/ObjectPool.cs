using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo
{
    public GameObject obj;
    public Transform transform;
    public Collider colider;
    public Rigidbody body;
    public Coroutine timer;

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

    public IEnumerator HideToTime(float time)
    {
        yield return new WaitForSeconds(time);
        SetActive(false);
    }
}

public class ObjectPool : MonoBehaviour
{
    public ObjectInfo[] objects;
    public GameObject[] prefabs;
    public int length = 2;
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

    public void CreateObjectPool(GameObject[] prefabs, Vector3 position)
    {
        this.prefabs = prefabs;
        _InitPrefabs(null, position);
    }

    public void CreateObjectPool(GameObject[] prefabs, Transform parent, Vector3 position)
    {
        this.prefabs = prefabs;
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
        objects = new ObjectInfo[prefabs.Length * length];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = new ObjectInfo();
        }

        int j = 0;

        foreach (GameObject prefab in prefabs)
        {
            for (int i = 0; i < length; i++)
            {
                objects[j].obj = Instantiate(prefab);
                objects[j].transform = objects[j].obj.transform;

                if (parent != null)
                    objects[j].transform.parent = parent;

                objects[j].obj.transform.position = position;
                objects[j].colider = objects[j].obj.GetComponentInChildren<Collider>();
                objects[j].body = objects[j].obj.GetComponentInChildren<Rigidbody>();

                objects[j].SetActive(false);
                j++;
            }
        }
    }

    public ObjectInfo PeekRandom()
    {
        currentObjectInPool = Random.Range(0, length * prefabs.Length);
        var obj = objects[currentObjectInPool];
        return obj;
    }

    public ObjectInfo NextInPool()
    {
        var obj = objects[currentObjectInPool];
        currentObjectInPool += 1;
        if (currentObjectInPool >= length * prefabs.Length)
        {
            currentObjectInPool = 0;
        }
        return obj;
    }

}
