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

        protected override void ConfigureEntity(ref EcsEntity ecsEntity)
        {
            playerComponentLink.ApplyComponentOnEntity(ref ecsEntity);
            moveInputComponentLink.ApplyComponentOnEntity(ref ecsEntity);
        }
    }
}