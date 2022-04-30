using NakusiTest.Common;
using UnityEngine;

namespace NakusiTest.UI
{
    public class BarUI : MonoBehaviour, IRemainderIndicator
    {
        [SerializeField]
        private Transform bar;

        private float _maxAmount;
        private float _curAmount;

        public void Init(float curAmount, float maxAmount)
        {
            _curAmount = curAmount;
            _maxAmount = maxAmount;
            Rescale();
        }

        public void OnChange(float curAmount)
        {
            _curAmount = curAmount;
            Rescale();
        }

        private void Rescale()
        {
            var scale = bar.localScale;
            bar.localScale = new Vector3(_curAmount/_maxAmount, scale.y, scale.z);
        }
    }
}