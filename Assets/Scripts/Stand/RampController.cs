using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    public Ramp ramp;
 
    private void Start()
    {
        ramp.FastController();
    }

    private void OnTriggerEnter(Collider other)
    {
        CarComp.Instance.NitroEffect.SetActive(true);
        CarComp.Instance.WindEffect.SetActive(true);
        CarComp.Instance.CarRb.AddForce(-CarComp.Instance.CarTransform.forward *  ramp.fastCount, ForceMode.Impulse);
    }
    
    private void OnTriggerExit(Collider other)
    {
        CarComp.Instance.NitroEffect.SetActive(false);
        Invoke("SetFalse",2.5f);
    }

    private void SetFalse()
    {
        CarComp.Instance.WindEffect.SetActive(false);
    }
}
