using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;

namespace Core.Player.Systems
{
    public class PlayerPositionSyncSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTagComponent, PositionComponent, CachedTransformRefComponent> _ecsFilter;

        public void Run()
        {
            foreach (var i in _ecsFilter)
            {
                var positionCompRef = _ecsFilter.Get2Ref(i);
                var cachedTransformCompRef = _ecsFilter.Get3Ref(i);

                ref var positionComponent = ref positionCompRef.Unref();
                ref var cachedTransformComponent = ref cachedTransformCompRef.Unref();

                cachedTransformComponent.CachedTransform.CacheTransform.position = positionComponent.Value;
            }
        }
    }
}