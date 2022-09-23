using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

public class FinalController : MonoBehaviour
{
     [SerializeField] private FinalRoadExp roadExp;


     private void Start()
     {
          roadExp.ExpRates();
          RoadControl();
     }


     private void RoadControl()
     {
          transform.GetComponent<TMP_Text>().text = "X" + roadExp.PointCount;
     }

     private void OnTriggerEnter(Collider other)
     {
          Debug.Log(roadExp.Rate);
          if (other.CompareTag("Car"))
          {
               PlayerProperties.Instance.PlayerCurrentMoney *= (int)roadExp.PointCount;
  
               CarComp.Instance.FuelBurnRate += roadExp.BurnRate;
          }
     }
     
}
