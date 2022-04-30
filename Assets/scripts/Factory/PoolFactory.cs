using System;
using UnityEngine;
using NakusiTest.Common;

namespace NakusiTest.Factory
{
    public class PoolFactory : MonoBehaviour, IFactory
    {
        private IStock _stock;
        private ObjectPool<IPoolable> _pool;

        public void Awake()
        {
            _stock = GetComponent<IStock>();
            _pool = new ObjectPool<IPoolable>(CreateElement, OnGet, OnRelease);
        }

        public void Create(Vector3 pos)
        {
            var element = _pool.Get();
            element.GameObject.transform.position = pos;
        }

        private IPoolable CreateElement()
        {
            var obstacleObj = Instantiate(_stock.GetNextTemplate(), transform);
            var element = obstacleObj.GetComponent<IPoolable>();
            if (element == null)
            {
                throw new Exception($"{gameObject.name} - Prefab in the stock should implement interface IPoolable for use in PoolFactory");
            }

            element.SetDestroyCallback(OnObstacleDestroy);
            return element;
        }

        private void OnGet(IPoolable element)
        {
            element.OnCreate();
            element.GameObject.SetActive(true);
        }

        private void OnRelease(IPoolable element)
        {
            element.OnRelease();
            element.GameObject.SetActive(false);
        }

        private void OnObstacleDestroy(IPoolable element)
        {
            _pool.Release(element);
        }
    }
}