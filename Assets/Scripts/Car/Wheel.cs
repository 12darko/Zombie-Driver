using System;
using UnityEngine;

namespace Car
{
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public WheelEnum enums;
    }
}
