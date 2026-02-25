using System;
using UnityEngine;

namespace Core.Movement.Components
{
    [Serializable]
    public struct CachedTransformRefComponent
    {
        [SerializeField] private CachedTransform cachedTransform;
        
        public CachedTransform CachedTransform => cachedTransform;
    }
}