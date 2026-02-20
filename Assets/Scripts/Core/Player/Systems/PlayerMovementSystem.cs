using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.Player.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, MoveInputComponent> _ecsFilter;

        public void Run()
        {
            foreach (var i in _ecsFilter)
            {
                var playerCompRef = _ecsFilter.Get1Ref(i);
                var moveInputCompRef = _ecsFilter.Get2Ref(i);

                ref var moveInputComponent = ref moveInputCompRef.Unref();
                var moveValue = moveInputComponent.Value;
                
                MovePlayer(playerCompRef, moveValue);
            }
        }

        private void MovePlayer(EcsComponentRef<PlayerComponent> playerCompRef, Vector2 moveValue)
        {
            if (moveValue.magnitude == 0f)
            {
                return;
            }

            if (moveValue.sqrMagnitude > 1f)
            {
                moveValue.Normalize();
            }

            ref var playerComponent = ref playerCompRef.Unref();

            var moveDirection = new Vector3(moveValue.x, 0f, moveValue.y);
            playerComponent.Player.PlayerTransform.position += moveDirection * Time.deltaTime;
        }
    }
}