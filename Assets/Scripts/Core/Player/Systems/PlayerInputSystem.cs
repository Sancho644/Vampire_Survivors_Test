using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Player.Systems
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<PlayerComponent, MoveInputComponent> _ecsFilter;

        private PlayerInputActions _inputActions;
        private InputAction _moveAction;

        public void Init()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();

            _moveAction = _inputActions.Player.Move;
        }

        public void Run()
        {
            var moveValue = _moveAction.ReadValue<Vector2>();

            foreach (var i in _ecsFilter)
            {
                var moveInputCompRef = _ecsFilter.Get2Ref(i);
                ref var moveInputComponent = ref moveInputCompRef.Unref();

                moveInputComponent.Value = moveValue;
            }
        }

        public void Destroy()
        {
            _inputActions.Disable();
        }
    }
}