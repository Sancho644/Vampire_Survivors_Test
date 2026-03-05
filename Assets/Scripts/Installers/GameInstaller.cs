using Core.Ecs;
using Core.Enemies;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private EcsStartup ecsStartup;
        [SerializeField] private EnemyFactory enemyFactory;

        public override void InstallBindings()
        {
            Container.Bind<EcsStartup>().FromInstance(ecsStartup);
            Container.BindInstance(enemyFactory).AsSingle();
        }
    }
}