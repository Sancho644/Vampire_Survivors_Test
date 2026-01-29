using Script.GameEvents;
using Zenject;

namespace Script.Installers
{
    public class GameEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameEventsDispatcher>().AsSingle();
        }
    }
}