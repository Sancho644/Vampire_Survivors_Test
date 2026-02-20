using UnityEngine;

namespace Game.States
{
    public class BootstrapState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter to BootStrapState");
            // Загрузка конфигов
        }

        public void Exit()
        {
            Debug.Log("Exit from BootStrapState");
        }
    }
}