using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObject : MonoBehaviour
{
    ObjectInfo info;
    Coroutine HideCoroutine;

    private void Awake()
    {
        info.obj = gameObject;
        info.colider = GetComponent<Collider>();
        info.body = GetComponent<Rigidbody>();
    }

    private void Hide()
    {
        if (HideCoroutine == null)
        {
            HideCoroutine = StartCoroutine(HideToTime(3));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Hide();
        }
    }

    private IEnumerator HideToTime(float time)
    {
        yield return new WaitForSeconds(time);
        info.obj.SetActive(false);
    }
}
