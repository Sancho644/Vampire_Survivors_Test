using Core.Ecs;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private EcsStartup ecsStartup;

        public override void InstallBindings()
        {
            Container.Bind<EcsStartup>().FromInstance(ecsStartup);
        }
    }
}