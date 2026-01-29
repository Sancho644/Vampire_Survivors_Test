using Leopotam.Ecs;
using UnityEngine;

namespace Core.Ecs
{
    public class MonoLink<T> : MonoBehaviour
        where T : struct
    {
        public T Component;
        public EcsComponentRef<T> EcsCompRef { get; private set; }

        public EcsComponentRef<T> ApplyComponentOnEntity(ref EcsEntity entity)
        {
            PrepareComponent(ref Component);
            entity.Replace(Component);
            EcsCompRef = entity.Ref<T>();
            OnEntityConfigured(ref entity);
            return EcsCompRef;
        }

        protected virtual void PrepareComponent(ref T targetComponent) { }
        protected virtual void OnEntityConfigured(ref EcsEntity entity) { }
    }
}