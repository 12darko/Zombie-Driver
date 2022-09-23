using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            CarComp.Instance.GameFinish = true;
            
            PlayerProperties.Instance.PlayerCurrentMoney = CarComp.Instance.CarBackCurrentGold;
            
            CarComp.Instance.CarBackCurrentGold = 90;
        }
    }
}
