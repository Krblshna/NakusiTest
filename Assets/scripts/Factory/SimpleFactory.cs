using UnityEngine;

namespace NakusiTest.Factory
{
    public class SimpleFactory : MonoBehaviour, IFactory
    {
        private IStock _stock;
        void Awake()
        {
            _stock = GetComponent<IStock>();
        }
        public void Create(Vector3 pos)
        {
            var obstacleObj = Instantiate(_stock.GetNextTemplate(), transform);
            obstacleObj.transform.position = pos;
        }
    }
}