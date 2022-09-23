using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (CarComp.Instance.CarRespawnTransform.rotation.y <= -0.96f)
        {
            Invoke("RespawnCar", 2f);
        }
        else
        {
            CancelInvoke("RespawnCar");
        }
        if (!CarComp.Instance.GameFinish)
        {
            UIElements.Instance.PlateText.text = CarComp.Instance.CarBackCurrentGold.ToString();
        }
        else
        {
            UIElements.Instance.PlateText.text = PlayerProperties.Instance.PlayerCurrentMoney.ToString();
            CarComp.Instance.WindEffect.SetActive(false);
            CarComp.Instance.NitroEffect.SetActive(true);
            if (CarComp.Instance.CurrentFuelStatus <= 0)
            {
                CarComp.Instance.ConfettiEffect.SetActive(true);
                CarComp.Instance.NitroEffect.SetActive(false);
            }
            else
            {
                CarComp.Instance.ConfettiEffect.SetActive(false);

            }
        }
        CarComp.Instance.CurrentFuelStatus = Mathf.Clamp(CarComp.Instance.CurrentFuelStatus , 0, 100);
    }
    
    
    public void RespawnCar()
    {
        CarComp.Instance.CarRespawnTransform.position = CarComp.Instance.CarCurrentSavedTransform;
        CarComp.Instance.CarRespawnTransform.rotation = Quaternion.Euler(0f,-90.0f, 0f);
        CarComp.Instance.CarRb.velocity = Vector3.zero;
    }
}