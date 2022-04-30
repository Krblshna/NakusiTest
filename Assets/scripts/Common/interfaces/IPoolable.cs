using System;
using UnityEngine;

namespace NakusiTest.Common
{
    public interface IPoolable
    {
        GameObject GameObject { get; }
        void SetDestroyCallback(Action<IPoolable> onDestroyAction);
        void OnCreate();
        void OnRelease();
    }
}