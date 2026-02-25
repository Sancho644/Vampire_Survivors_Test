using Core.Enemies.Components;
using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.Enemies.Systems
{
    public class EnemyMovementSystem : IEcsRunSystem
    {
        private const float SqrMagnitudeTolerance = 0.0001f;
        
        private readonly EcsFilter<PlayerTagComponent, PositionComponent> _playerFilter;
        private readonly EcsFilter<EnemyTagComponent, PositionComponent> _enemyFilter;

        public void Run()
        {
            if (_playerFilter.IsEmpty())
            {
                return;
            }

            var playerPosCompRef = _playerFilter.Get2Ref(0);

            var playerPosition = playerPosCompRef.Unref().Value;
            var deltaTime = Time.deltaTime;

            foreach (var i in _enemyFilter)
            {
                var enemyPosCompRef = _enemyFilter.Get2Ref(i);
                ref var enemyPositionComponent = ref enemyPosCompRef.Unref();

                var direction = playerPosition - enemyPositionComponent.Value;
                var sqrMagnitude = direction.x * direction.x + direction.z * direction.z;

                if (sqrMagnitude < SqrMagnitudeTolerance)
                    continue;

                var invLength = 1f / Mathf.Sqrt(sqrMagnitude);

                direction *= invLength;

                enemyPositionComponent.Value += direction * deltaTime;
            }
        }
    }
}