using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.MonoBehaviours.Persons.Enemies;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Points
{
    public class Point : MonoBehaviour
    {
        [SerializeField] 
        private List<Enemy> _enemies;
        protected internal bool CheckActiveEnemies()
        {
            return _enemies.Any(enemy => enemy.GetComponent<Collider>().enabled);
        }

        protected internal void ActivateEnemies(Vector3 playerPosition)
        {
            foreach (var enemy in _enemies)
            {
                enemy.InitializeEnemy(playerPosition);
            }
        }
    }
}