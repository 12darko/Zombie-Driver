using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ChestAnimation : MonoBehaviour
{
    //Private Variables
    [SerializeField] private Animator chestAnimation;
    [SerializeField] private Transform coin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            chestAnimation.SetTrigger("Open");
            CoinAnimation(other);
        }
    }

    private void CoinAnimation(Collider other)
    {
        var holderTransform =
            CarComp.Instance.ItemHolderTransform[Random.Range(0, CarComp.Instance.ItemHolderTransform.Length)];
        coin.transform.SetParent(holderTransform);
        coin.DOLocalMove(Vector3.zero, 15f, false).SetEase(Ease.Linear).SetSpeedBased()
            .OnComplete(() =>
            {
                if (other.attachedRigidbody.TryGetComponent(out Collector collector))
                {
                    coin.transform.SetParent(null);
                    collector.AddNewItem(CarComp.Instance.CollectedCoins.transform, 1);
                }
                Destroy(coin.gameObject);
            });
       
    }
}