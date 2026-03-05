using UnityEngine;
using Zenject;

namespace Core.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyMonoEntity prefab;

        [Inject] private IInstantiator _instantiator;

        public EnemyMonoEntity CreateEnemy(Transform parent)
        {
            var enemyMonoEntity = _instantiator.InstantiatePrefabForComponent<EnemyMonoEntity>(prefab, parent);

            return enemyMonoEntity;
        }
    }
}