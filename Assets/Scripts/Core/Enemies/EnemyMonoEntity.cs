using Core.Ecs;
using Core.Enemies.Components;
using Core.Movement.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.Enemies
{
    public class EnemyMonoEntity : AbstractMonoEntity
    {
        [SerializeField] private EnemyTagComponentLink enemyTagComponentLink;
        [SerializeField] private CachedTransformRefComponentLink cachedTransformRefComponentLink;
        [SerializeField] private PositionComponentLink positionComponentLink;
        
        protected override void ConfigureEntity(ref EcsEntity ecsEntity)
        {
            enemyTagComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            cachedTransformRefComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            positionComponentLink.ApplyComponentOnEntity(ref ecsEntity);
        }
    }
}