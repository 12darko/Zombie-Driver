using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy Type", menuName = "Object Type")]
    public class EnemyType : ScriptableObject
    {
        [SerializeField] private Material enemyColorMaterial;
        [SerializeField] private string enemyName;
        [SerializeField] private float enemySpeed;
        [SerializeField] private float enemyMaxHealth;
        [SerializeField] private float enemyAttackDamage;
        [SerializeField] private float enemyRotationSpeed;
        [SerializeField] private float enemyChaseSpeed;
        [SerializeField] private float enemyChaseDelay;

        public Material EnemyColorMaterial
        {
            get => enemyColorMaterial;
            set => enemyColorMaterial = value;
        }

        public string EnemyName
        {
            get => enemyName;
            set => enemyName = value;
        }

        public float EnemySpeed
        {
            get => enemySpeed;
            set => enemySpeed = value;
        }

        public float EnemyMaxHealth
        {
            get => enemyMaxHealth;
            set => enemyMaxHealth = value;
        }

        public float EnemyAttackDamage
        {
            get => enemyAttackDamage;
            set => enemyAttackDamage = value;
        }

        public float EnemyRotationSpeed
        {
            get => enemyRotationSpeed;
            set => enemyRotationSpeed = value;
        }

        public float EnemyChaseSpeed
        {
            get => enemyChaseSpeed;
            set => enemyChaseSpeed = value;
        }

        public float EnemyChaseDelay
        {
            get => enemyChaseDelay;
            set => enemyChaseDelay = value;
        }
    }
}
