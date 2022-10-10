using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.MonoBehaviours
{
    public class Pool<T> where T : MonoBehaviour
    {
        private T Prefab { get; }
        private Transform Container { get; }

        private List<T> _pool = new List<T>();

        public Pool(T prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var obj in _pool.Where(obj => !obj.gameObject.activeInHierarchy))
            {
                element = obj;
                obj.gameObject.SetActive(true);
                return true;
            }
            
            element = null;
            Debug.Log(element.name);
            return false;
        }

        public T GetFreeElement()
        {
           return HasFreeElement(out var element) ? element : CreateObject(true);
        }
    }
}