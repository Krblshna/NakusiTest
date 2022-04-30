using System;
namespace NakusiTest.Common
{
    public interface IHealth
    {
        void SubscribeOnChange(Action<float> action);
        void UnsubscribeOnChange(Action<float> action);
        void Restore();
        void Change(float delta);
        void Init();
    }
}