using UnityEngine;

namespace NakusiTest.Factory
{
    public interface IStock
    {
        GameObject GetNextTemplate();
    }
}