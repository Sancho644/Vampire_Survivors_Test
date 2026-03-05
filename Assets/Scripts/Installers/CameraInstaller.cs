using UnityEngine;
using Zenject;

namespace Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;

        public override void InstallBindings()
        {
            Container.BindInstance(mainCamera).AsSingle();
        }
    }
}