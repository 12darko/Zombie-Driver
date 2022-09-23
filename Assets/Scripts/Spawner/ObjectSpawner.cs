using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObjectSpawner : MonoBehaviour
{
   [SerializeField] private GameObject[] spawnObject;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         int randomIndex = Random.Range(0, spawnObject.Length);

         Vector3 randomSpawnPosition = new Vector3(Random.Range(-5f, 5f), 2, Random.Range(-10, 10f));

         Instantiate(spawnObject[randomIndex], randomSpawnPosition, Quaternion.identity);
      }
   }
}
