using UnityEngine;

namespace NakusiTest.Factory
{
    public class MultipleStock : MonoBehaviour, IStock
    {
        [SerializeField] private GameObject[] _prefabs;
        public GameObject GetNextTemplate()
        {
            return _prefabs[Random.Range(0, _prefabs.Length)];
        }
    }
}