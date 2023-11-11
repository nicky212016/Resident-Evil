using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player, init;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hola");
            enemy.SetDestination(player.position);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        enemy.SetDestination(init.position);
    }

}