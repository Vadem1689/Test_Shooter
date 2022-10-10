using System;

namespace Assets.Scripts.MonoBehaviours.Persons.Enemies
{
    public class Bonus : Enemy
    {
        internal static event Action ChangeWeaponEvent;

        private protected override void StopAttack()
        {
            ChangeWeaponEvent?.Invoke();
        }
    }
}