using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientBehaviour : MonoBehaviour, IPooledObject

{
[SerializeField]
    private NavMeshAgent agent;

    public float clientSpeed = 2f;

    private int indexNextDestination = -1;

    private TargetPoint[] targetPoints;

    private Vector3 destination;



    void start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;                  // allows for continuous movement between points

        clientSpeed = agent.speed;
    }

    void update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

    private void NextDestination()
    {

        indexNextDestination++;
        indexNextDestination = indexNextDestination % targetPoints.Length;
        destination = targetPoints[indexNextDestination].GivePoint();
        //Debug.Log("test", gameObject);
        agent.SetDestination(destination);

    }

    public void OnObjectSpawn()
    {
        agent.Move(transform.forward * Time.deltaTime);

    }
}
