using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Collector : MonoBehaviour
{
    private void Start()
    {
        CarComp.Instance.CarBackCurrentGold = 8;
        AddNewItem(CarComp.Instance.CollectedCoins.transform, CarComp.Instance.CarBackCurrentGold);
      
        CarComp.Instance.ParticleEffect.SetActive(false);
    }
    
    public void AddNewItem(Transform itemToAdd, int itemCount)
    {
        for (int i = 0; i < itemCount; i++)
        {
            var tr = GetParent();

            var go = Instantiate(itemToAdd, tr, true);
            go.localPosition = new Vector3(0, 0.10f * tr.childCount, 0f);
            go.localRotation = Quaternion.identity;
        }
        CarComp.Instance.ParticleEffect.SetActive(true);
        DOVirtual.DelayedCall(0.6f, (() => CarComp.Instance.ParticleEffect.SetActive(false)));
    }
    
    private Transform GetParent()
    {
        var holderTransform = CarComp.Instance.ItemHolderTransform[Random.Range(0, CarComp.Instance.ItemHolderTransform.Length)];
        if (holderTransform.childCount >= 10)
        {
            return GetParent();
        }

        return holderTransform;
    }
}