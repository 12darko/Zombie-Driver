using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[Serializable]
public struct FinalRoadExp
{
    public FinalRoadExpRate Rate;
    public float PointCount;
    public float BurnRate;

        public void ExpRates()
        {
            switch (Rate)
            {
                case FinalRoadExpRate.X1:
                    PointCount = 1;
                    BurnRate = 7;
                    break;
                case FinalRoadExpRate.X2:
                    PointCount = 2;
                    BurnRate = 10;
                    break;
                case FinalRoadExpRate.X5:
                    PointCount = 5;
                    BurnRate = 13;
                    break;
                case FinalRoadExpRate.X7:
                    PointCount = 7;
                    BurnRate = 17;
                    break;
                case FinalRoadExpRate.X9:
                    PointCount = 9;
                    BurnRate = 20;
                    break;
                case FinalRoadExpRate.X12:
                    PointCount = 12;
                    BurnRate = 22;
                    break;
                case FinalRoadExpRate.X15:
                    PointCount = 15;
                    BurnRate = 25;
                    break;
                case FinalRoadExpRate.X18:
                    PointCount = 18;
                    BurnRate = 28;
                    break;
            }
        }
}
