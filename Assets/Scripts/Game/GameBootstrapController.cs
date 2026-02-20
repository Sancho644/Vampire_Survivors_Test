using Game.States;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameBootstrapController : MonoBehaviour
    {
        [Inject] private readonly GameStateMachine _gameStateMachine;

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}