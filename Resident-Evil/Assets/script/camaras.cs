using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class camaras : MonoBehaviour
{
    public Transform player;
    public CinemachineVirtualCamera activeCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entro");
            activeCam.Priority = 1; //1 para activar, 0 para desactivar

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0; //1 para activar, 0 para desactivar
        }
    }

}

