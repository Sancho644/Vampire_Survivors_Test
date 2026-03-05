using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Core.Enemies.Systems
{
    public class EnemySpawnSystem : IEcsRunSystem
    {
        //Убрать в конфиг
        private const float EnemySpawnInterval = 5f;
        private const float EnemySpawnOffset = 2f;
        private const int EnemySpawnCount = 1000;

        [Inject] private readonly Camera _camera;
        
        private readonly EcsFilter<PlayerTagComponent, PositionComponent> _playerFilter = null;
        private readonly EcsFilter<EnemyPoolComponent> _poolFilter = null;

        private float _spawnTimer;

        public void Run()
        {
            if (_playerFilter.IsEmpty())
            {
                return;
            }

            _spawnTimer += Time.deltaTime;

            if (_spawnTimer < EnemySpawnInterval)
            {
                return;
            }

            _spawnTimer = 0f;

            foreach (var i in _poolFilter)
            {
                var poolCompRef = _poolFilter.Get1Ref(i);
                ref var poolComponent = ref poolCompRef.Unref();

                var activeEnemies = poolComponent.EnemyPool.GetActiveItemsCount();

                if (activeEnemies >= EnemySpawnCount)
                {
                    continue;
                }

                SpawnEnemy(poolCompRef);
            }
        }

        // Проверить математику
        private void SpawnEnemy(EcsComponentRef<EnemyPoolComponent> poolCompRef)
        {
            ref var poolComponent = ref poolCompRef.Unref();

            ref var playerPos = ref _playerFilter.Get2(0);
            var playerPosition = playerPos.Value;

            var height = _camera.orthographicSize * 2f;
            var width = height * _camera.aspect;

            var halfHeight = height / 2f;
            var halfWidth = width / 2f;

            var radius = Mathf.Max(halfWidth, halfHeight) + EnemySpawnOffset;
            var angle = Random.Range(0f, Mathf.PI * 2f);

            var spawnPosition = playerPosition + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
            var enemyMonoEntity = poolComponent.EnemyPool.Get();

            // Под вопросом
            if (!enemyMonoEntity.PositionComponentLink.EcsCompRef.IsNull())
            {
                ref var positionComponent = ref enemyMonoEntity.PositionComponentLink.EcsCompRef.Unref();
                positionComponent.Value = spawnPosition;
            }
        }
    }
}