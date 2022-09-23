using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Player;
using Stand;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;


public class StandsController : MonoBehaviour
{
    //Data
    [SerializeField] private Stands stand;

    [SerializeField] private GameObject fuelSymbol;

    private void Awake()
    {
        stand.ExpRates();
        StandsControl();
    }


    private void StandsControl()
    {
        fuelSymbol.SetActive(false);

        switch (stand.Type)
        {
            case StandType.Exp:
                //Get Exp
                transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text =
                    "X" + stand.PointCount;
                break;
            case StandType.Fuel:
                fuelSymbol.SetActive(true);
                transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().gameObject
                    .SetActive(false);
                break;
            case StandType.FuelDecrease:
                fuelSymbol.SetActive(true);
                transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().gameObject
                    .SetActive(false);
                break;
            //Get Fuel
            case StandType.Money:
                //Get Money
                transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text =
                    "X" + stand.PointCount;

                break;
            case StandType.Divided:
                transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text =
                    "÷" + stand.PointCount;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Get Gold Or Exp Or Fuel 
        if (!other.CompareTag("Car")) return;

        switch (stand.Type)
        {
            case StandType.Exp:
                //Get Exp
                var _currentExp = PlayerProperties.Instance.CurrentPlayerExp *= stand.PointCount;
               // UIElements.Instance.ExpText.text = _currentExp.ToString();
                Destroy(gameObject);
                break;
            //Get Fuel
            case StandType.Fuel:
                var _randomFuelValue = Random.Range(5, 100);
                CarComp.Instance.CurrentFuelStatus += _randomFuelValue;
                Debug.Log(_randomFuelValue);
                Destroy(gameObject);
                break;
           
            case StandType.FuelDecrease:
                var _randomFuelDecreaseValue = Random.Range(5, 50);
                CarComp.Instance.CurrentFuelStatus -=_randomFuelDecreaseValue;
                Debug.Log(_randomFuelDecreaseValue);
                Destroy(gameObject);
                break;
            case StandType.Money:
                //Get Money
                if (other.attachedRigidbody != null)
                {
                    if (other.attachedRigidbody.TryGetComponent(out Collector collector))
                    {
                        var temp = CarComp.Instance.CarBackCurrentGold;

                        CarComp.Instance.CarBackCurrentGold *= (int)stand.PointCount;

                        var temp2 = CarComp.Instance.CarBackCurrentGold;
                        temp2 = Mathf.Clamp(temp2, 0, 90);
                        var diff = temp2 - temp;
                        collector.AddNewItem(CarComp.Instance.CollectedCoins.transform,
                            diff);
                        Destroy(gameObject);

                        Debug.Log(stand.Rate);
                    }
                }

                break;
            case StandType.Divided:
                var temp3 = CarComp.Instance.CarBackCurrentGold;
                var temp4 = CarComp.Instance.CarBackCurrentGold / (int)stand.PointCount;
                CoinManager.Instance.CoinDecrease(temp3 - temp4,null);
                Destroy(gameObject);
                break;
        }
    }
}