using Scripts.GameEvents;
using Zenject;

namespace Scripts.Installers
{
    public class GameEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameEventsDispatcher>().AsSingle();
        }
    }
}