using Assets.Scripts.MonoBehaviours.Persons.Player;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Weapons
{
    public class Leg : Weapon
    {
        private void OnTriggerEnter(Collider other)
        {
            var person = other.gameObject.GetComponent<Player>();
            if (person)
            {
                person.SetDamage(Damage);
            }
        }
    }
}
