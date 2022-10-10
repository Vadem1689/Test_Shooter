using System.Collections.Generic;
using Assets.Scripts.MonoBehaviours.Weapons;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviours.Persons
{
    public abstract class Person : MonoBehaviour
    {
        private protected const string Run = "Run";
        private protected const string Idle = "Idle";
        private protected const string Attack = "Attack";

        [SerializeField, Range(0f, 30f)] 
        private float _maxHealth;

        [SerializeField] 
        private Slider _healthSlider;

        [SerializeField] 
        private List<Rigidbody> _bonesList;

        [SerializeField] 
        private Weapon _weapon;

        private float _currentHealth;
        private Collider _collider;

        protected Animator PersonAnimator;
        protected NavMeshAgent Agent;

        protected Weapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _currentHealth = _maxHealth;
            PersonAnimator = GetComponent<Animator>();
            _collider = GetComponent<Collider>();
            Agent = GetComponent<NavMeshAgent>();

            _healthSlider.value = CalculateSliderHealthValue();
            SetKinematic(true);
        }

        private float CalculateSliderHealthValue()
        {
            return _currentHealth / _maxHealth;
        }

        private void SetKinematic(bool isKinematic)
        {
            foreach (var bone in _bonesList)
            {
                bone.isKinematic = isKinematic;
            }
        }

        internal void SetDamage(float damage)
        {
            _currentHealth -= damage;
            _healthSlider.value = CalculateSliderHealthValue();

            if (_currentHealth <= 0)
            {
                PersonAnimator.enabled = false;
                _collider.enabled = false;
                _healthSlider.gameObject.SetActive(false);
                SetKinematic(false);
                Killed();
            }
        }

        private protected virtual void Killed()
        {

        }
    }
}
