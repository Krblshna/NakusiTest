using UnityEngine;


namespace NakusiTest.Factory
{
    public class OneTimeSpawner : MonoBehaviour
    {
        [SerializeField] private int amount = 3;
        private IFactory _factory;
        private IArea _obstaclesArea;

        void Start()
        {
            _factory = GetComponent<IFactory>();
            _obstaclesArea = GetComponent<IArea>();
            Spawn();
        }

        private void Spawn()
        {
            for (var i = 0; i < amount; i++)
            {
                var pos = _obstaclesArea.GetRandomPosition();
                _factory.Create(pos);
            }
        }
    }
}