using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        [Inject] private readonly EnemyFactory _enemyFactory;

        private readonly Stack<EnemyMonoEntity> _pool = new();

        //Прогреть пул до игры
        public EnemyMonoEntity Get()
        {
            if (_pool.Count == 0)
            {
                CreateNew();
            }

            var enemyMonoEntity = _pool.Pop();
            enemyMonoEntity.gameObject.SetActive(true);
            return enemyMonoEntity;
        }

        public void Return(EnemyMonoEntity enemyMonoEntity)
        {
            enemyMonoEntity.gameObject.SetActive(false);
            _pool.Push(enemyMonoEntity);
        }

        //Проверить
        public int GetActiveItemsCount()
        {
            var count = 0;
            foreach (var enemy in _pool)
            {
                if (enemy.gameObject.activeSelf)
                {
                    count++;
                }
            }

            return count;
        }

        private EnemyMonoEntity CreateNew()
        {
            var enemyMonoEntity = _enemyFactory.CreateEnemy(parent);
            enemyMonoEntity.gameObject.SetActive(false);
            _pool.Push(enemyMonoEntity);

            return enemyMonoEntity;
        }
    }
}