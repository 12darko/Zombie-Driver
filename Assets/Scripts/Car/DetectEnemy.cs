using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EMA.Scripts.Utils;
using Enemy;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DetectEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombie"))
        {
            
            var carPos = transform.position;
           
             EnemyHealth(100, collision);
            if (collision.gameObject.GetComponent<EnemyController>().currentHealth <= 0)
            {
                collision.gameObject.GetComponent<EnemyController>().ragdollController.SetActiveOfRagdoll(true);
                foreach (var rigidbody in   collision.gameObject.GetComponent<EnemyController>().ragdollController.Rigidbodies)
                {
                    rigidbody.AddExplosionForce(100f * (CarComp.Instance.CarRb.velocity.magnitude / 10f), collision.contacts[0].point, 6f, 3.0f, ForceMode.Impulse);
                }

                //Mobun Gücüne Dayalı
               CoinManager.Instance.CoinDecrease(5, null);
               
            }
        }
    }
    
    public void EnemyHealth(float amount, Collision collision)
    {
        collision.gameObject.GetComponent<EnemyController>().currentHealth -= amount;
    }
}