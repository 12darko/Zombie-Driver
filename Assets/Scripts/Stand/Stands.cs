using System;
using System.Diagnostics;

namespace Stand
{
    [Serializable]
    public struct Stands
    {
        public StandType Type;
        public StandExpRate Rate;
        public float PointCount;

        public void ExpRates()
        {
            switch (Rate)
            {
                case StandExpRate.X1:
                    PointCount = 1;
                    break;
                case StandExpRate.X2:
                    PointCount = 2;
                    break;
                case StandExpRate.X5:
                    PointCount = 5;
                    break;
                case StandExpRate.X7:
                    PointCount = 7;
                    break;
                case StandExpRate.X9:
                    PointCount = 9;
                    break;
                case StandExpRate.X12:
                    PointCount = 12;
                    break;
                case StandExpRate.X15:
                    PointCount = 15;
                    break;
                case StandExpRate.X18:
                    PointCount = 18;
                    break;
            }
        }
    }
}