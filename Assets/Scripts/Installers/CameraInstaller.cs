using UnityEngine;
using Zenject;

namespace Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera camera;

        public override void InstallBindings()
        {
            Container.BindInstance(camera).AsSingle();
        }
    }
}