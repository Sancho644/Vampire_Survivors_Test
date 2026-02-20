using System;
using UnityEngine;

namespace Core.Player.Components
{
    [Serializable]
    public struct PlayerComponent
    {
        [SerializeField] private Player player;
        
        public Player Player => player;
    }
}