﻿using UnityEngine;

namespace Player.States
{
    public class PlayerStateMachine
    {
        private IPlayerState _currentState;

        public IPlayerState CurrentState => _currentState;

        public void SetState(IPlayerState newState)
        {
            if (_currentState?.GetType() == newState?.GetType())
                return; 

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}