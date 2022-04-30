using System.Collections;
using UnityEngine;


namespace NakusiTest.Factory
{
    public class DelaySpawner : MonoBehaviour
    {
        [SerializeField] private float minDelayBetweenSpawn = 0;
        [SerializeField] private float maxDelayBetweenSpawn = 1f;

        private bool _processActive;
        private IEnumerator _processEn;

        private IFactory _factory;
        private IArea _obstaclesArea;

        void Start()
        {
            _processEn = StartProcess();
            StartCoroutine(_processEn);
            _factory = GetComponent<IFactory>();
            _obstaclesArea = GetComponent<IArea>();
        }

        public void StopProcess()
        {
            StopCoroutine(_processEn);
            _processActive = false;
        }

        IEnumerator StartProcess()
        {
            _processActive = true;
            while (_processActive)
            {
                var delay = Random.Range(minDelayBetweenSpawn, maxDelayBetweenSpawn);
                yield return new WaitForSeconds(delay);
                var pos = _obstaclesArea.GetRandomPosition();
                _factory.Create(pos);
            }
        }
    }
}