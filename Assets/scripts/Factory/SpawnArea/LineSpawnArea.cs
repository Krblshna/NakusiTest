using UnityEngine;

namespace NakusiTest.Factory
{
    public class LineSpawnArea : MonoBehaviour, IArea
    {
        [SerializeField] private float deltaX;

        public Vector3 GetRandomPosition()
        {
            var pos = transform.position;
            var randomX = pos.x + Random.Range(-deltaX, deltaX);
            return new Vector3(randomX, pos.y, 0);
        }
    }
}