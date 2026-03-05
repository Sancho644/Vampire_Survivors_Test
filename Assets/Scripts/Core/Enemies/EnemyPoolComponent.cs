using System;
using UnityEngine;

namespace Core.Enemies
{
    [Serializable]
    public struct EnemyPoolComponent
    {
        [SerializeField] private EnemyPool enemyPool;

        public EnemyPool EnemyPool => enemyPool;
    }
}