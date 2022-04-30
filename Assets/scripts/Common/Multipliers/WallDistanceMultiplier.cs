using UnityEngine;

namespace NakusiTest.Common
{
    public class WallDistanceMultiplier : MonoBehaviour, IMultiplier
    {
        [SerializeField] private LayerMask _mask;
        public float Multiply(float damageAmount)
        {
            RaycastHit2D hitLeft = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.left * 10, _mask);
            RaycastHit2D hitRight = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.right * 10, _mask);
            if (hitLeft.collider == null || hitRight.collider == null)
            {
                return damageAmount;
            }
            var distance = Vector2.Distance(hitLeft.transform.position, hitRight.transform.position);
            return damageAmount / distance;
        }
    }
}