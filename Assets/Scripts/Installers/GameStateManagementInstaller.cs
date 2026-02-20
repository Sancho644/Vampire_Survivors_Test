using Game;
using Zenject;

namespace Installers
{
    public class GameStateManagementInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
        }
    }
}