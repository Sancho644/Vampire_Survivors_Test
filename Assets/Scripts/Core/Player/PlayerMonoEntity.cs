using Core.Ecs;
using Core.Movement.Components;
using Core.Player.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.Player
{
    public class PlayerMonoEntity : AbstractMonoEntity
    {
        [SerializeField] private PlayerComponentLink playerComponentLink;
        [SerializeField] private MoveInputComponentLink moveInputComponentLink;
        [SerializeField] private PlayerTagComponentLink playerTagComponentLink;
        [SerializeField] private PositionComponentLink positionComponentLink;
        [SerializeField] private CachedTransformRefComponentLink cachedTransformRefComponentLink;

        protected override void ConfigureEntity(ref EcsEntity ecsEntity)
        {
            playerComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            moveInputComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            playerTagComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            positionComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            cachedTransformRefComponentLink.ApplyComponentOnEntity(ref ecsEntity);
        }
    }
}