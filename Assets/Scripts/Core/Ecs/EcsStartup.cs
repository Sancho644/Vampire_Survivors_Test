using Core.Enemies.Systems;
using Core.Player.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Core.Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        public EcsWorld World => _world ??= new EcsWorld();
        private EcsSystems Systems => _systems ??= new EcsSystems(World);

        private EcsWorld _world;
        private EcsSystems _systems;

        [Inject] private readonly IInstantiator _instantiator;

        private void Start()
        {
            Systems
                .Add(_instantiator.Instantiate<PlayerInputSystem>())
                .Add(_instantiator.Instantiate<PlayerMovementSystem>())
                .Add(_instantiator.Instantiate<EnemyMovementSystem>())
                .Add(_instantiator.Instantiate<EnemyPositionSyncSystem>())
                .Add(_instantiator.Instantiate<PlayerPositionSyncSystem>());

            Systems.Init();
        }

        private void Update()
        {
            Systems?.Run();
        }

        private void OnDestroy()
        {
            Systems.Destroy();
            World.Destroy();
        }
    }
}