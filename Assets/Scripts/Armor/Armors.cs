using System;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class Armors : MonoBehaviour
{
   public string ArmorName;
   public string ArmorPlace;
   public int ArmorId;
   public Vector3 ArmorLocation;
   public Sprite ArmorImage;
   public GameObject ArmorPrefabs;
   public float ArmorFuelDecreaseRate;
   public float ArmorCarSpeedIncrease;
   public bool ArmorIsBuying;

   private Armors(string armorName, string armorPlace, int armorId, Vector3 armorLocation, Sprite armorImage, GameObject armorPrefabs , float armorFuelDecreaseRate, bool armorIsBuying, float armorCarSpeedIncrease)
   {
      ArmorName = armorName;
      ArmorPlace = armorPlace;
      ArmorId = armorId;
      ArmorLocation = armorLocation;
      ArmorImage = armorImage;
      ArmorPrefabs = armorPrefabs;
      ArmorFuelDecreaseRate = armorFuelDecreaseRate;
      ArmorIsBuying = armorIsBuying;
      ArmorCarSpeedIncrease = armorCarSpeedIncrease;
   }
}
