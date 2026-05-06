using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Core.GameCamera.Systems
{
    public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        [Inject] private readonly Camera _camera;

        private readonly EcsFilter<PlayerTagComponent, PositionComponent> _ecsFilter = null;

        private Transform _cameraTransform;

        public void Init()
        {
            _cameraTransform = _camera.transform;
        }

        public void Run()
        {
            if (_ecsFilter.IsEmpty())
            {
                return;
            }

            ref var positionComponent = ref _ecsFilter.Get2Ref(0).Unref();

            var playerPosition = positionComponent.Value;
            var pos = _cameraTransform.position;

            pos.x = playerPosition.x;
            pos.z = playerPosition.z;
            _cameraTransform.position = pos;
            Debug.Log($"{_cameraTransform.position}");
        }
    }
}