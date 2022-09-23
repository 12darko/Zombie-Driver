 
using System;
using UnityEngine;

public class RespawnCar : MonoBehaviour
{
    private const int  decreaseCoinValue  = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
           UIManager.Instance.RespawnCar(); 
           CoinManager.Instance.CoinDecrease(decreaseCoinValue,null);
        }
    }
}