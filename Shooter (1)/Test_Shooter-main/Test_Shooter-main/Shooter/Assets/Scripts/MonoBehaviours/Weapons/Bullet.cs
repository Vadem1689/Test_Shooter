using System.Collections;
using Assets.Scripts.MonoBehaviours.Persons;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private const float LifeTime = 3f;

        [SerializeField, Range(0f, 50f)] 
        private float _speed;

        private Vector3 _target;
        private float _damage;
        private Transform _transform;
        
        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnEnable()
        {
            StartCoroutine(DisableBulletByTime());
        }

        private void OnDisable()
        {
            StopCoroutine(DisableBulletByTime());
        }
        
        private void FixedUpdate()
        {
            var step = _speed * Time.deltaTime;
            _transform.position = Vector3.MoveTowards(_transform.position, _target, step);
        }

        private void OnCollisionEnter(Collision other)
        {
            DisableBullet();
        }

        private void OnTriggerEnter(Collider other)
        {
            var person = other.gameObject.GetComponent<Person>();
            if (person)
            {
                person.SetDamage(_damage);
            }
            DisableBullet();
        }

        public void Initialize(Vector3 startPosition, Vector3 target, float damage)
        {
            transform.position = startPosition;
            _target = target;
            _damage = damage;
        }

        private IEnumerator DisableBulletByTime()
        {
            yield return new WaitForSeconds(LifeTime);
            DisableBullet();
        }
        
        private void DisableBullet()
        {
            gameObject.SetActive(false);
        }
    }
}
