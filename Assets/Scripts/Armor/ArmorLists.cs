using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ArmorLists : MonoBehaviour
{
     [SerializeField] private Armors[] armors;
     [SerializeField] private Transform armorContent;
     [SerializeField] private Transform carHolder;

     private Button btnBuy;

     private void Start()
     {
          ListArmors();
     }

     private void ListArmors()
     {
          foreach (var armorItems in armors)
          {
               GameObject armorListItemObject = Instantiate(armorItems.gameObject, armorContent);
               armorListItemObject.transform.localScale = Vector3.one;
               btnBuy = armorListItemObject.transform.GetChild(0).GetComponent<Button>();
               btnBuy.onClick.AddListener(delegate
               {
                    var position = new Vector3(armorItems.ArmorLocation.x, armorItems.ArmorLocation.y,
                         armorItems.ArmorLocation.z);
                    var go =  Instantiate(armorItems.ArmorPrefabs, position, quaternion.identity , carHolder);
                    go.transform.localRotation = Quaternion.identity;
                    CarComp.Instance.FuelBurnRate  -= armorItems.ArmorFuelDecreaseRate;
                    CarComp.Instance.MaxAcceleration += armorItems.ArmorCarSpeedIncrease;
                    BtnBuyControl(armorItems.ArmorId);//Button Fonksiyonları

               });
               armorListItemObject.transform.GetChild(1).GetComponent<Image>().sprite = armorItems.ArmorImage;
               armorListItemObject.transform.GetChild(2).GetComponent<TMP_Text>().text = armorItems.ArmorName;
         
          }
     }


     private void BtnBuyControl(int armorId)
     {
          Debug.Log(armorId);
          btnBuy = armorContent.GetChild(armorId).GetChild(0).GetComponent<Button>();
          btnBuy.interactable = false;

     }
}
