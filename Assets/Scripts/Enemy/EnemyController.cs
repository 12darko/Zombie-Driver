using System;
using System.Collections;
using System.Collections.Generic;
using EMA.Scripts.Utils;
using Enemy;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [Header("Scriptable Object")]
   [SerializeField] private EnemyType enemyType;
   [Header("Components")]
   [SerializeField] private Rigidbody zombieRb;
   [SerializeField] private SphereCollider detectCollider;
   [SerializeField] private Animator zombieAnimator;

   [Header("Variable")]
   [SerializeField] private bool isRbMove = true;
   [SerializeField] private float triggerArea;
   [SerializeField] private bool isDetected = false;
   [SerializeField] private Vector3 targetPos;
   
   public RagdollController ragdollController;
   public float currentHealth;
   
   private Transform targetTrans;
 
   private void Start()
   {
      currentHealth = enemyType.EnemyMaxHealth;
      if (detectCollider)
      {
         detectCollider.radius = triggerArea;
      }
   }

   private void Update()
   {
      if (isDetected && targetTrans != null)
      {
          Follow(targetTrans);
      }
   }

   private void Follow(Transform target)
   {
      var moveSpeed = enemyType.EnemyChaseSpeed;

      targetPos = target.position;
      targetPos.y = transform.localPosition.y;

      if (isRbMove)
      {
         Rotate(target);
         zombieRb.MovePosition(zombieRb.position + transform.forward * (moveSpeed * Time.deltaTime));
         zombieAnimator.SetBool("isMove", true);
      }
      else
      {
         zombieAnimator.SetBool("isMove", false);
         StopChasing();
      }
   }

   private void Rotate(Transform target)
   {
      Vector3 localTarget = transform.InverseTransformPoint(target.position);
      
      float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
      
      Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);
      Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * (Time.deltaTime * enemyType.EnemyRotationSpeed));
      zombieRb.MoveRotation(zombieRb.rotation * deltaRotation);
   }

   private void OnTriggerEnter(Collider other)
   {
       if(isDetected) return;

       if (other.CompareTag("Car"))
       {
          Debug.Log("Detected "+ other.name);
          isDetected = true;
          StartCoroutine(ActivateChasing(other.transform, enemyType.EnemyChaseDelay));
       }
       else
       {
          StopChasing();
          isDetected = false;
       }
   }
   
   IEnumerator ActivateChasing(Transform other, float _waitSec = 1f)
   {
      yield return new WaitForSeconds(_waitSec);
      targetTrans = other;
   }
   
   
   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.blue;
      //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
      Gizmos.DrawWireSphere(this.transform.position, triggerArea);
   }
 
   public void StopChasing()
   {
      isDetected = false;
   }
   
}
