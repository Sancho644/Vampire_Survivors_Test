using Core.Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.Enemies
{
    public class EnemyPoolEntity : AbstractMonoEntity
    {
        [SerializeField] private EnemyPoolMonoLink enemyPoolMonoLink;
        
        protected override void ConfigureEntity(ref EcsEntity ecsEntity)
        {
            enemyPoolMonoLink.ApplyComponentOnEntity(ref ecsEntity);
        }
    }
}