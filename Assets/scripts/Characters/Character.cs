using System;
using NakusiTest.Common;
using UnityEngine;

namespace NakusiTest.Characters
{
    public class Character : MonoBehaviour, IPoolable, IDamageable
    {
        public GameObject GameObject => gameObject;
        private Action<IPoolable> _onDestroyAction;
        private IHealth _health;

        private void Awake()
        {
            _health = GetComponentInChildren<IHealth>();
        }

        public void SetDestroyCallback(Action<IPoolable> onDestroyAction)
        {
            _onDestroyAction = onDestroyAction;
        }

        public void OnCreate()
        {
            _health?.Restore();
            _health?.SubscribeOnChange(OnHpChange); 
        }

        public void OnRelease()
        {
            _health?.UnsubscribeOnChange(OnHpChange);
        }

        private void OnHpChange(float hp)
        {
            if (Math.Abs(hp) < 0.1f)
            {
                _onDestroyAction?.Invoke(this);
            }
        }

        public void Damage(float damageAmount)
        {
            _health?.Change(-damageAmount);
        }
    }
}