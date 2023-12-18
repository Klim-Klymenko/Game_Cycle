using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace GameCycle
{
    [DefaultExecutionOrder(-2500)]
    public sealed class GameManagerInstaller : IInitializable
    {
        private readonly GameManager _gameManager;
        private readonly IReadOnlyList<IGameListener> _gameListeners;
        
        public GameManagerInstaller(GameManager gameManager, IReadOnlyList<IGameListener> gameListeners)
        {
            _gameManager = gameManager;
            _gameListeners = gameListeners;
        }
        
        void IInitializable.Initialize()
        {
            for (int i = 0; i < _gameListeners.Count; i++)
                _gameManager.AddListener(_gameListeners[i]);
        }
    }
}