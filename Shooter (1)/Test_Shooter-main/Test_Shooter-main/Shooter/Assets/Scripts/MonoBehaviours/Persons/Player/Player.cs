using System;
using Assets.Scripts.MonoBehaviours.Points;
using Assets.Scripts.MonoBehaviours.UI.ScreenViews;
using Assets.Scripts.MonoBehaviours.Weapons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MonoBehaviours.Persons.Player
{
    public class Player : Person
    {
        private const float Distance = 0.2f;
        
        internal static event Func<Vector3> DestinationPosition;
        internal static event Func<bool> HaveActiveEnemies;
        internal static event Action<Vector3, Vector3, float> ShootEvent;
        internal static event Action<Vector3> ActivateEnemiesEvent;

        private bool _isRunning;
        private bool _canShoot;

        private void Update()
        {
            if (_isRunning)
            {
                CheckDestination();
            }

            if (_canShoot && Input.GetMouseButtonDown(0))
            {
                Shoot();
                PersonAnimator.SetTrigger(Attack);
            }
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
            StartMenuScreenView.StartGameEvent += StartGame;
            WayPoints.CanContinueMovingEvent += ContinueMoving;
            Armament.UpdatePlayerWeapon += UpdateWeapon;
        }

        private void UnsubscribeFromEvents()
        {
            StartMenuScreenView.StartGameEvent -= StartGame;
            WayPoints.CanContinueMovingEvent -= ContinueMoving;
            Armament.UpdatePlayerWeapon -= UpdateWeapon;
        }

        private void StartGame()
        {
            ContinueMoving();
        }

        private void SetPlayerDestination()
        { 
            Agent.SetDestination((Vector3) DestinationPosition?.Invoke());
        }

        private void CheckDestination()
        {
            if(Vector3.Distance(transform.position, Agent.destination) < Distance)
            {
                _isRunning = false;

                if ((bool) HaveActiveEnemies?.Invoke())
                {
                    PersonAnimator.SetTrigger(Idle);
                    _canShoot = true;
                    ActivateEnemiesEvent?.Invoke(transform.position);
                }
                else
                {
                   ContinueMoving();
                }
            }
        }

        private void Shoot()
        {
            var pos = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(new Vector3(pos.x, pos.y, 0));

            if (Physics.Raycast(ray, out var hit))
            {   
                ShootEvent?.Invoke(Weapon.Barrel.position, hit.point, Weapon.Damage);
            }
        }

        private void ContinueMoving()
        {
            SetPlayerDestination();
            _isRunning = true;
            _canShoot = false;
            PersonAnimator.SetTrigger(Run);
        }

        private void UpdateWeapon(Weapon newWeapon)
        {
            Weapon = newWeapon;
        }

        private protected override void Killed()
        {
            SceneManager.LoadScene(2);
        }
    }
}