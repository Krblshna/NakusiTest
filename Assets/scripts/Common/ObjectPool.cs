using System;
using System.Collections.Generic;

namespace NakusiTest.Common
{
    public class ObjectPool<T>
    {
        public delegate T CreateObstacle();

        private readonly CreateObstacle _createAction;
        private readonly Action<T> _onReleaseAction, _onGetAction;
        private readonly Stack<T> _pool = new Stack<T>();

        public ObjectPool(CreateObstacle createAction, Action<T> onGetAction, Action<T> onReleaseAction)
        {
            _createAction = createAction;
            _onGetAction = onGetAction;
            _onReleaseAction = onReleaseAction;
        }

        public T Get()
        {
            T element = _pool.Count > 0 ? _pool.Pop() : _createAction();
            _onGetAction.Invoke(element);
            return element;
        }

        public void Release(T element)
        {
            if (_pool.Contains(element)) return;
            _onReleaseAction.Invoke(element);
            _pool.Push(element);
        }
    }
}