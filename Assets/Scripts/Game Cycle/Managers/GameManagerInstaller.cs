using UnityEngine;

namespace GameCycle
{
    public sealed class GameManagerInstaller
    {
        private readonly GameManager _gameManager;

        public GameManagerInstaller(GameManager gameManager) => _gameManager = gameManager;

        public void InstallListeners()
        {
            MonoBehaviour[] sceneComponents = GetSceneComponents();
            
            for (int i = 0; i < sceneComponents.Length; i++)
            {
                if (sceneComponents[i] is IGameListener gameListener)
                    _gameManager.AddListener(gameListener);
            }
        }
        
        private MonoBehaviour[] GetSceneComponents()
        {
            return Object.FindObjectsOfType<MonoBehaviour>(true);
        }
    }
}