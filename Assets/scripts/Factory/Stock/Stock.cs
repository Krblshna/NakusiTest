using UnityEngine;

namespace NakusiTest.Factory
{
    public class Stock : MonoBehaviour, IStock
    {
        [SerializeField] private GameObject _prefab;
        public GameObject GetNextTemplate()
        {
            return _prefab;
        }
    }
}