using Assets.Scripts.MonoBehaviours.Persons.Enemies;
using Assets.Scripts.MonoBehaviours.Persons.Player;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Weapons
{
    public class BulletsPool : MonoBehaviour
    {
        [SerializeField]
        private int _poolCount = 10;
        [SerializeField]
        private Bullet _prefab;

        private Pool<Bullet> _pool;

        private void Awake()
        {
            _pool = new Pool<Bullet>(_prefab, _poolCount, transform);
        }

        private void OnEnable()
        {
            SubscribeOnEvents();
        }

        private void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeOnEvents()
        {
            Player.ShootEvent += ActivateBullet;
            ShooterEnemy.ShootEvent += ActivateBullet;
        }

        private void UnsubscribeFromEvents()
        {
            Player.ShootEvent -= ActivateBullet;
            ShooterEnemy.ShootEvent -= ActivateBullet;
        }

        public void ActivateBullet(Vector3 barrelPosition, Vector3 target, float damage)
        {
            _pool.GetFreeElement().Initialize(barrelPosition, target, damage);
        }
    }
}
