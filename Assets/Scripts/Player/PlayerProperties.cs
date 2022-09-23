using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace Player
{
    public class PlayerProperties : MonoSingleton<PlayerProperties>
    {
        private float totatlPlayerExp;
        private float currentPlayerExp;
        private float playerTotalMoney;
        [SerializeField]  private float playerCurrentMoney;
        
        public float TotalPlayerExp
        {
            get => totatlPlayerExp;
            set => totatlPlayerExp = value;
        }

        public float CurrentPlayerExp
        {
            get => currentPlayerExp;
            set => currentPlayerExp = value;
        }

        public virtual float PlayerTotalMoney
        {
            get => playerTotalMoney;
            set => playerTotalMoney = value;
        }

      public virtual float PlayerCurrentMoney
        {
            get => playerCurrentMoney;
            set => playerCurrentMoney = value;
        }

 
    }
}
