using UnityEngine;
using System;

namespace NakusiTest.Common
{
    public class Health : MonoBehaviour, IHealth, IExhaustible
    {
        private event Action<float> OnChange;
        private float _hp;
        public float Hp
        {
            get => _hp;
            private set
            {
                _hp = value;
                OnChange?.Invoke(_hp);
            }
        }
        [field: SerializeField]
        public float MaxHp { get; private set; }

        public float CurValue => Hp;
        public float MaxValue => MaxHp;

        public void SubscribeOnChange(Action<float> action)
        {
            OnChange += action;
        }

        public void UnsubscribeOnChange(Action<float> action)
        {
            OnChange -= action;
        }

        public void Restore()
        {
            Hp = MaxHp;
        }
        public void Change(float delta)
        {
            Hp = Mathf.Clamp(Hp + delta, 0, MaxHp);
        }

        public void Init()
        {
            Restore();
        }
    }
}