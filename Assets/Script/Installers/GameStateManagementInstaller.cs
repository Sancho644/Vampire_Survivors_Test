using Script.Game;
using Zenject;

namespace Script.Installers
{
    public class GameStateManagementInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
        }
    }
}