using System;
using System.Collections.Generic;
using Script.Game.States;
using Zenject;
using IState = Script.Game.States.IState;

namespace Script.Game
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        [Inject] private readonly IInstantiator _instantiator;

        [Inject]
        public void PostInject()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = _instantiator.Instantiate<BootstrapState>(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}