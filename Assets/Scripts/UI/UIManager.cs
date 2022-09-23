using System;
using System.Collections;
using System.Collections.Generic;
using EMA.Scripts.PatternClasses;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
  
    

   public void RespawnCarUITrue()
   {
       UIElements.Instance.RespawnPanel.SetActive(true);
   }
   
   public void RespawnCarUIFalse()
   {
       UIElements.Instance.RespawnPanel.SetActive(false);
   }


   public void RespawnCar()
   {
       CarComp.Instance.CarRespawnTransform.position = CarComp.Instance.CarCurrentSavedTransform;
       CarComp.Instance.CarRespawnTransform.rotation = Quaternion.Euler(0f,-90.0f, 0f);
       CarComp.Instance.CarRb.velocity = Vector3.zero;
   }
}
