using UnityEngine;
using Zenject;

namespace Scripts.GameEvents
{
    public class GameEventsController : MonoBehaviour
    {
        [Inject] private readonly IGameEventsDispatcher _gameEventsDispatcher;

        private void Update()
        {
            while (_gameEventsDispatcher.HasEventInQueue())
            {
                _gameEventsDispatcher.InvokeEventInQueue();
            }
        }
    }
}