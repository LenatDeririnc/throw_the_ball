using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObject : MonoBehaviour
{
    public GameObject obj;
    ObjectInfo info;

    private void Awake()
    {
        info = new ObjectInfo();
        info.obj = obj;
        info.colider = obj.GetComponentInChildren<Collider>();
        info.body = obj.GetComponentInChildren<Rigidbody>();
    }

    private void AddScoreAndHide()
    {
        GameManager.self.CurrentScore += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            AddScoreAndHide();
        }
    }
}
