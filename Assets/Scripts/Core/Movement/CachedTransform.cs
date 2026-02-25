using UnityEngine;

namespace Core.Movement
{
    public class CachedTransform : MonoBehaviour
    {
        public Transform CacheTransform { get; private set; }

        private void Awake()
        {
            CacheTransform = transform;
        }
    }
}