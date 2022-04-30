using System;

namespace NakusiTest.Common
{
    public interface IExhaustible
    {
        float CurValue { get; }
        float MaxValue { get; }
        void SubscribeOnChange(Action<float> action);
        void UnsubscribeOnChange(Action<float> action);
    }
}