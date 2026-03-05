using System;
using UnityEngine;

namespace Core.Movement.Components
{
    [Serializable]
    public struct CachedTransformComponent
    {
        [SerializeField] private CachedTransform cachedTransform;
        
        public CachedTransform CachedTransform => cachedTransform;
    }
}