using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public float radius = 1f;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Client", transform.position, Quaternion.identity);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.5f, 0.9f, 0.4f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
