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
                .Add(_instantiator.Instantiate<PlayerMovementSystem>());
                
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