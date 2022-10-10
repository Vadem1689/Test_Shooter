using System;
using System.Collections.Generic;
using Assets.Scripts.MonoBehaviours.Persons.Enemies;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Weapons
{
    public class Armament : MonoBehaviour
    {
        internal static event Action<Weapon> UpdatePlayerWeapon;

        [SerializeField]
        private List<Weapon> _weapons;

        private int _currentWeapon;

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
            Bonus.ChangeWeaponEvent += ChangeWeapon;
        }

        private void UnsubscribeFromEvents()
        {
            Bonus.ChangeWeaponEvent -= ChangeWeapon;
        }

        private void ChangeWeapon()
        {
            _weapons[_currentWeapon].gameObject.SetActive(false);
            _currentWeapon++;
            _weapons[_currentWeapon].gameObject.SetActive(true);
            UpdatePlayerWeapon?.Invoke(_weapons[_currentWeapon]);
        }
    }
}