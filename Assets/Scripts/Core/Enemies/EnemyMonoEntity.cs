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
        [SerializeField] private CachedTransformComponentLink cachedTransformComponentLink;
        [SerializeField] private PositionComponentLink positionComponentLink;
        
        public PositionComponentLink PositionComponentLink => positionComponentLink;
        
        protected override void ConfigureEntity(ref EcsEntity ecsEntity)
        {
            enemyTagComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            cachedTransformComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            positionComponentLink.ApplyComponentOnEntity(ref ecsEntity);
        }
    }
}