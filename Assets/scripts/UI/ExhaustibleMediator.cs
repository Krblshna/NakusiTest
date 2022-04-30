using NakusiTest.Common;
using UnityEngine;

namespace NakusiTest.UI
{
    public class ExhaustibleMediator : MonoBehaviour
    {
        private IRemainderIndicator _remainder;
        private IExhaustible _exhaustible;

        private void Awake()
        {
            _exhaustible = transform.GetComponent<IExhaustible>();
            _remainder = transform.GetComponentInChildren<IRemainderIndicator>();
            _exhaustible.SubscribeOnChange(_remainder.OnChange);
            _remainder.Init(_exhaustible.CurValue, _exhaustible.MaxValue);
        }
    }
}