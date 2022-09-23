using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spike : MonoBehaviour
{
    [SerializeField] private float decraseFuel;

    private void Start()
    {
        decraseFuel = Random.Range(0, 50);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            CarComp.Instance.CurrentFuelStatus -= decraseFuel;
        }
    }
}
