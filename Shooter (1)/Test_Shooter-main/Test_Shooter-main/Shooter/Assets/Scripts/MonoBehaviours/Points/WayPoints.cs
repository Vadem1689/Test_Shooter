using System;
using System.Collections.Generic;
using Assets.Scripts.MonoBehaviours.Persons.Enemies;
using Assets.Scripts.MonoBehaviours.Persons.Player;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Points
{
    public class WayPoints : MonoBehaviour
    {
        internal static event Action CanContinueMovingEvent;
        internal static event Action WinEvent;

        [SerializeField] 
        private List<Point> _pointsList;

        private int _currentWayPointIndex;
        private Vector3 _currentDestinationPosition;

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
            Player.DestinationPosition += GetCurrentWayPointPosition;
            Player.HaveActiveEnemies += HaveActiveEnemies;
            Player.ActivateEnemiesEvent += ActivateEnemiesAtCurrentPoint;
            Enemy.KilledEnemyEvent += CheckActiveEnemiesAfterKilling;
        }
        
        private void UnsubscribeFromEvents()
        {
            Player.DestinationPosition -= GetCurrentWayPointPosition;
            Player.HaveActiveEnemies -= HaveActiveEnemies;
            Player.ActivateEnemiesEvent -= ActivateEnemiesAtCurrentPoint;
            Enemy.KilledEnemyEvent -= CheckActiveEnemiesAfterKilling;
        }

        private Vector3 GetCurrentWayPointPosition()
        {
            if (IsNotAllPointsComplete())
            {
                _currentDestinationPosition = _pointsList[_currentWayPointIndex].transform.position;
            }
            else
            {
                WinEvent?.Invoke();
            }
            return _currentDestinationPosition;
        }
        
        private bool HaveActiveEnemies()
        {
            if (IsNotAllPointsComplete())
            {
                var result = _pointsList[_currentWayPointIndex].CheckActiveEnemies();
                if (!result)
                {
                    _currentWayPointIndex++;
                }

                return result;
            }
            return false;
        }

        private void ActivateEnemiesAtCurrentPoint(Vector3 playerPosition)
        {
            _pointsList[_currentWayPointIndex].ActivateEnemies(playerPosition);
        }

        private void CheckActiveEnemiesAfterKilling()
        {
            if (!HaveActiveEnemies())
            {
                CanContinueMovingEvent?.Invoke();
            }
        }

        private bool IsNotAllPointsComplete()
        {
            return _currentWayPointIndex <= _pointsList.Count - 1;
        }
    }
}
