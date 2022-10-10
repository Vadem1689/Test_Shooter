using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField, Range(0f, 5f)] 
        private float _damage;

        [SerializeField] 
        private Transform _barrel;
        
        internal float Damage => _damage;
        internal Transform Barrel => _barrel;

    }
}