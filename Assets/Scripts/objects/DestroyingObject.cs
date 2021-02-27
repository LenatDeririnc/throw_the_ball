using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObject : MonoBehaviour
{
    ObjectInfo info;

    private void Awake()
    {
        info.obj = gameObject;
        info.colider = GetComponent<Collider>();
        info.body = GetComponent<Rigidbody>();
    }

    private void AddScoreAndHide()
    {
        GameManager.self.CurrentScore += 1;
        info.obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            AddScoreAndHide();
        }
    }
}
