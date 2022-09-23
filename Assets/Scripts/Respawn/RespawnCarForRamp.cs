using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCarForRamp : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Invoke("RespawnCar",4f); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("RespawnCar");  
    }

    public void RespawnCar()
    {
        CarComp.Instance.CarRespawnTransform.position = CarComp.Instance.CarCurrentSavedTransform;
        CarComp.Instance.CarRespawnTransform.rotation = Quaternion.Euler(0f,-90.0f, 0f);
        CarComp.Instance.CarRb.velocity = Vector3.zero;
    }
}
