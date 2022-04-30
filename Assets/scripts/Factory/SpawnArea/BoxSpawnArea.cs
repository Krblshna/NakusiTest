using UnityEngine;

namespace NakusiTest.Factory
{
    public class BoxSpawnArea : MonoBehaviour, IArea
    {
        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
        }
        public Vector3 GetRandomPosition()
        {
            var boxBounds = _collider.bounds;
            var center = boxBounds.center;
            var extents = boxBounds.extents;
            var randomX = center.x + Random.Range(-extents.x, extents.x);
            var randomY = center.y + Random.Range(-extents.y, extents.y);
            return new Vector3(randomX, randomY, 0);
        }
    }
}