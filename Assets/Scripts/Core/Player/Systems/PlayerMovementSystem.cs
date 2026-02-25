using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.Player.Systems
{
    public class PlayerMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, MoveInputComponent, PositionComponent> _ecsFilter;

        public void Init()
        {
            foreach (var i in _ecsFilter)
            {
                var playerCompRef = _ecsFilter.Get1Ref(i);
                var positionCompRef = _ecsFilter.Get3Ref(i);

                ref var playerComponent = ref playerCompRef.Unref();
                ref var positionComponent = ref positionCompRef.Unref();

                positionComponent.Value = playerComponent.Player.PlayerTransform.position;
            }
        }

        public void Run()
        {
            var deltaTime = Time.deltaTime;

            foreach (var i in _ecsFilter)
            {
                var moveInputCompRef = _ecsFilter.Get2Ref(i);
                var positionCompRef = _ecsFilter.Get3Ref(i);

                ref var moveInputComponent = ref moveInputCompRef.Unref();
                var moveValue = moveInputComponent.Value;

                if (moveValue.sqrMagnitude <= 0f)
                {
                    continue;
                }

                if (moveValue.sqrMagnitude > 1f)
                {
                    moveValue.Normalize();
                }

                var direction = new Vector3(moveValue.x, 0f, moveValue.y);

                ref var positionComponent = ref positionCompRef.Unref();

                positionComponent.Value += direction * deltaTime;
            }
        }
    }
}