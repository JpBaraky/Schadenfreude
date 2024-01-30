using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicArea : MonoBehaviour
{
    public bool isOnArea;


    
 private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered Mic Area
         
            isOnArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited Mic Area
         
            isOnArea = false;
        }
    }
}