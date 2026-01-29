using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Core.Ecs
{
    public abstract class AbstractMonoEntity : MonoBehaviour
    {
        [Inject] private EcsStartup _ecsStartup;

        private EcsEntity _ecsEntity;

        public EcsEntity EcsEntity => _ecsEntity;

        [Inject]
        private void PostInject()
        {
            _ecsEntity = _ecsStartup.World.NewEntity();
            PostInjectInternal();
        }

        private void Awake()
        {
            ConfigureEntity(ref _ecsEntity);
            OnAwake();
        }

        private void OnDestroy()
        {
            if (_ecsEntity.IsWorldAlive())
            {
                _ecsEntity.Destroy();
            }
            OnDestroyInternal();
        }

        protected virtual void PostInjectInternal() { }

        protected virtual void OnDestroyInternal() { }

        protected virtual void OnAwake() { }

        protected abstract void ConfigureEntity(ref EcsEntity ecsEntity);
    }
}