using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

namespace Car
{
    public class TestDrive : MonoBehaviour
    {
        

        
        public float maxSteerAngle = 30.0f;


        public List<Wheel> wheels;
        private float moveInput;
        private float steerInput;

        public Vector3 _centerOfMass;
      
        public bool isStop;
        
        private void Start()
        {
            isStop = false;
            CarComp.Instance.CarRb.centerOfMass = _centerOfMass;
            CarComp.Instance.CurrentFuelStatus = CarComp.Instance.TotalFuelStatus;
        }

        private void GetInput()
        {
            moveInput = UIElements.Instance.DynamicJoystick.Vertical;
            steerInput = UIElements.Instance.DynamicJoystick.Horizontal;
        }


        
        private void Move()
        {
            if (moveInput != 0 && isStop == false)
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.wheelCollider.motorTorque = -Mathf.Clamp(moveInput, 0, 0.9f) * 600 *  CarComp.Instance.MaxAcceleration * Time.deltaTime;
                    CarComp.Instance.CurrentFuelStatus -= CarComp.Instance.FuelBurnRate * Time.deltaTime;
                    wheel.wheelCollider.brakeTorque = 0;
                }
            }
            else
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.wheelCollider.brakeTorque = 1000 * CarComp.Instance.BreakeAcceleration * Time.deltaTime;
                }
            }
        }

        private void Steer()
        {
            foreach (Wheel wheel in wheels)
            {
                if (wheel.enums == WheelEnum.Front)
                {
                    var _steerAngle = steerInput * CarComp.Instance.TurnSensivity * maxSteerAngle;
                    wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
                }
            }
        }

        private void Update()
        {
            GetInput();
            WheelAnimation();
            //Fuel Bar Animation
            UIElements.Instance.FuelBar.fillAmount = CarComp.Instance.CurrentFuelStatus / CarComp.Instance.TotalFuelStatus;
        }

        private void LateUpdate()
        {
            if (CarComp.Instance.CurrentFuelStatus <= 1)
            {
                isStop = true;
                foreach (Wheel wheel in wheels)
                {
                    if (isStop)
                    {
                        wheel.wheelCollider.brakeTorque = 1000 * CarComp.Instance.BreakeAcceleration * Time.deltaTime;

                        CarComp.Instance.CurrentFuelStatus = 0;  
                    }
                }
            }
            else
            {

                if (UIElements.Instance.DynamicJoystick.transform.GetChild(0).GetChild(0).gameObject.activeSelf)
                {
                    Move(); 
                    Steer();
                }
                else
                {
                    Move(); 
                    Steer();
                }
            }
        }

        private void WheelAnimation()
        {
            foreach (var wheel in wheels)
            {
                Quaternion rot;
                Vector3 pos;
                wheel.wheelCollider.GetWorldPose(out pos, out rot);
                wheel.wheelModel.transform.position = pos;
                wheel.wheelModel.transform.rotation = rot;
            }
        }

      
      
        
        
        #region Brake Command
        private void Brake()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                foreach (var wheel in wheels)
                {
                    wheel.wheelCollider.brakeTorque = 300 * CarComp.Instance.BreakeAcceleration * Time.deltaTime;
                }
            }
            else
            {
                foreach (var wheel in wheels)
                {
                    wheel.wheelCollider.brakeTorque = 0;
                }
            }
        }

        #endregion
        
    }
}