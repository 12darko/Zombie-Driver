using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;

public class CoinManager : MonoSingleton<CoinManager>
{
    public void CoinDecrease(int dropCoinCount, GameObject targetPosition)
    {
        var temp = CarComp.Instance.CarBackCurrentGold;
        temp = Mathf.Clamp(temp, 0, 90);
        CarComp.Instance.CarBackCurrentGold -= dropCoinCount;
                
        CarComp.Instance.CarBackCurrentGold =  (int)Mathf.Clamp(CarComp.Instance.CarBackCurrentGold, 0, Mathf.Infinity);

        var loopCount = temp - CarComp.Instance.CarBackCurrentGold;
        if (CarComp.Instance.CarBackCurrentGold >= 90)
        {
            return;
        }

        for (int i = 0; i < loopCount; i++)
        {
                    
            var tr = GetParent();
            var z = tr.GetChild(tr.childCount - 1);

            var zPos = z.position;
            zPos.z -= 1F;
            z.SetParent(null);

            if (!CarComp.Instance.GameFinish)
                z.DOJump(
                    zPos, 5f,
                    1, 1, false).SetEase(Ease.Linear).OnComplete(() => Destroy(z.gameObject));
            else
                z.DOMove(targetPosition.transform.position, 0.7f, false).SetEase(Ease.Linear);
        }
    }
    
    
    private Transform GetParent()
    {
        var holderTransform =
            CarComp.Instance.ItemHolderTransform[Random.Range(0, CarComp.Instance.ItemHolderTransform.Length)];
        return holderTransform.childCount == 0 ? GetParent() : holderTransform;
    }
}
