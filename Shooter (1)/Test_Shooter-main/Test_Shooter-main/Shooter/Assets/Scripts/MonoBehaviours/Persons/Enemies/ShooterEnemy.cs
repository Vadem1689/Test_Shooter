using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MonoBehaviours.Persons.Enemies
{
    public class ShooterEnemy : Enemy
    {
        internal static event Action<Vector3, Vector3, float> ShootEvent;

        private bool _isShooting;

        private void Update()
        {
            transform.LookAt(PlayerPosition);
        }

        private protected override void Activate()
        {
            _isShooting = true;
            StartCoroutine(Shoot());
        }

        private protected override void StopAttack()
        {
            _isShooting = false;
            StopCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (_isShooting)
            {
                var randomTimeShoot = Random.Range(0.5f, 1.5f);
                PersonAnimator.SetTrigger(Attack);
                ShootEvent?.Invoke(Weapon.Barrel.position, PlayerPosition, Weapon.Damage);
                yield return new WaitForSeconds(randomTimeShoot);
            }
        }
    }
}
