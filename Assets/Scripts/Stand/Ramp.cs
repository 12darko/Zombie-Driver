using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Ramp
{
     public RampType rampType;
     public float fastCount;

     public void FastController()
     {
          switch (rampType)
          {
               case RampType.VERYFAST:
                    fastCount = 2500;
                    break;
               case RampType.FAST:
                    fastCount = 1500;
                    break;
               case RampType.MIDDLE:
                    fastCount = 1000;
                    break;
               case RampType.SLOW:
                    fastCount = 750;
                    break;
 
          }
     }
}
