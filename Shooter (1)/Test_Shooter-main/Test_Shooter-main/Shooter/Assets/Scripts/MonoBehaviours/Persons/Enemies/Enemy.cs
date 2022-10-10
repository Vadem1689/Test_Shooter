using System;
using Vector3 = UnityEngine.Vector3;

namespace Assets.Scripts.MonoBehaviours.Persons.Enemies
{
    public abstract class Enemy : Person
    {
        internal static event Action KilledEnemyEvent;

        protected Vector3 PlayerPosition;

        internal void InitializeEnemy(Vector3 playerPosition)
        {
            PlayerPosition = playerPosition;
            Activate();
        }
        
        private protected override void Killed()
        {
            KilledEnemyEvent?.Invoke();
            StopAttack();
        }

        private protected virtual void StopAttack()
        {

        }

        private protected virtual void Activate()
        {

        }
    }
}