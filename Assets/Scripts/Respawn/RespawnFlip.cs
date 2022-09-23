using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFlip : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            UIManager.Instance.RespawnCar();
        }
    }
}