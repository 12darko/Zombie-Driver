using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
  
    private void Update()
    {
        cameraTransform.position = CarComp.Instance.CarTransform.position;
    }
}
