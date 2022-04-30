using System;
using NakusiTest.Common;
using UnityEngine;

namespace NakusiTest.Obstacles
{
    public class Obstacle : MonoBehaviour, IPoolable
    {
        public GameObject GameObject => gameObject;
        [SerializeField] private float _damageAmount = 1;
        private IMultiplier _damageMultiplier;
        private Action<IPoolable> _onDestroyAction;

        void Awake()
        {
            _damageMultiplier = GetComponent<IMultiplier>();
        }

        void CheckCollision(Transform transform_)
        {
            if (transform_.tag.Equals(Tags.Ground))
            {
                _onDestroyAction?.Invoke(this);
                return;
            }
            var damageable = transform_.GetComponent<IDamageable>();
            if (damageable != null)
            {
                var damage = _damageMultiplier.Multiply(_damageAmount);
                damageable.Damage(damage);
                _onDestroyAction?.Invoke(this);
            }
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            CheckCollision(coll.transform);
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
            CheckCollision(coll.transform);
        }

        public void SetDestroyCallback(Action<IPoolable> onDestroyAction)
        {
            _onDestroyAction = onDestroyAction;
        }

        public void OnCreate(){}

        public void OnRelease(){}
    }
}