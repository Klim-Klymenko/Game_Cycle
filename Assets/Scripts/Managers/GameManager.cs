using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace GameCycle
{
    public sealed class GameManager : IInitializable, IStartable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        public GameState GameState { get; private set; }
        
        private readonly List<IInitializeGameListener> _initializeListeners = new();
        private readonly List<IStartGameListener> _startListeners = new();
        private readonly List<IUpdateGameListener> _updateListeners = new();
        private readonly List<IFixedUpdateGameListener> _fixedUpdateListeners = new();
        private readonly List<ILateUpdateGameListener> _lateUpdateListeners = new();
        private readonly List<IFinishGameListener> _finishListeners = new();
        private readonly List<IResumeGameListener> _resumeListeners = new();
        private readonly List<IPauseGameListener> _pauseListeners = new();

        void IInitializable.Initialize() => OnInitialize();

        void IStartable.Start() => OnStart();
        
        void ITickable.Tick() => OnUpdate();

        void IFixedTickable.FixedTick() => OnFixedUpdate();

        void ILateTickable.LateTick() => OnLateUpdate();

        void IDisposable.Dispose() => OnFinish();
        
        private void OnInitialize()
        {
            if (GameState != GameState.None) return;
            
            for (int i = 0; i < _initializeListeners.Count; i++)
                _initializeListeners[i].OnInitialize();
            
            GameState = GameState.Initialized;
        }
        
        private void OnStart()
        {
            if (GameState != GameState.Initialized) return;
            
            for (int i = 0; i < _startListeners.Count; i++)
                _startListeners[i].OnStart();
            
            GameState = GameState.Active;
        }
        
        private void OnUpdate()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _updateListeners.Count; i++)
                _updateListeners[i].OnUpdate();
        }
        
        private void OnFixedUpdate()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
                _fixedUpdateListeners[i].OnFixedUpdate();
        }
        
        private void OnLateUpdate()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
                _lateUpdateListeners[i].OnLateUpdate();
        }
        
        private void OnFinish()
        {
            if (GameState == GameState.Finished) return;
            
            for (int i = 0; i < _finishListeners.Count; i++)
                _finishListeners[i].OnFinish();
            
            GameState = GameState.Finished;
        }
        
        public void OnResume()
        {
            if (GameState != GameState.Paused) return;
            
            for (int i = 0; i < _resumeListeners.Count; i++)
                _resumeListeners[i].OnResume();
            
            GameState = GameState.Active;
        }
        
        public void OnPause()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _pauseListeners.Count; i++)
                _pauseListeners[i].OnPause();
            
            GameState = GameState.Paused;
        }
        
        public void AddListener(IGameListener listener)
        {
            if (listener is IInitializeGameListener initializeListener)
                if (!_initializeListeners.Contains(initializeListener))
                    _initializeListeners.Add(initializeListener);
            
            if (listener is IStartGameListener startListener)
                if (!_startListeners.Contains(startListener))
                    _startListeners.Add(startListener);
            
            if (listener is IUpdateGameListener updateListener)
                if (!_updateListeners.Contains(updateListener))
                    _updateListeners.Add(updateListener);
            
            if (listener is IFixedUpdateGameListener fixedUpdateListener)
                if (!_fixedUpdateListeners.Contains(fixedUpdateListener))
                    _fixedUpdateListeners.Add(fixedUpdateListener);
            
            if (listener is ILateUpdateGameListener lateUpdateListener)
                if (!_lateUpdateListeners.Contains(lateUpdateListener))
                    _lateUpdateListeners.Add(lateUpdateListener);
            
            if (listener is IFinishGameListener finishListener)
                if (!_finishListeners.Contains(finishListener))
                    _finishListeners.Add(finishListener);
            
            if (listener is IResumeGameListener resumeListener)
                if (!_resumeListeners.Contains(resumeListener))
                    _resumeListeners.Add(resumeListener);
            
            if (listener is IPauseGameListener pauseListener)
                if (!_pauseListeners.Contains(pauseListener))
                    _pauseListeners.Add(pauseListener);
        }

        public void RemoveListener(IGameListener listener)
        {
            if (listener is IInitializeGameListener initializeListener)
                if (_initializeListeners.Contains(initializeListener))
                    _initializeListeners.Remove(initializeListener);
            
            if (listener is IStartGameListener startListener)
                if (_startListeners.Contains(startListener))
                    _startListeners.Remove(startListener);
            
            if (listener is IUpdateGameListener updateListener)
                if (_updateListeners.Contains(updateListener))
                    _updateListeners.Remove(updateListener);
            
            if (listener is IFixedUpdateGameListener fixedUpdateListener)
                if (_fixedUpdateListeners.Contains(fixedUpdateListener))
                    _fixedUpdateListeners.Remove(fixedUpdateListener);
            
            if (listener is ILateUpdateGameListener lateUpdateListener)
                if (_lateUpdateListeners.Contains(lateUpdateListener))
                    _lateUpdateListeners.Remove(lateUpdateListener);
            
            if (listener is IFinishGameListener finishListener)
                if (_finishListeners.Contains(finishListener))
                    _finishListeners.Remove(finishListener);
            
            if (listener is IResumeGameListener resumeListener)
                if (_resumeListeners.Contains(resumeListener))
                    _resumeListeners.Remove(resumeListener);
            
            if (listener is IPauseGameListener pauseListener)
                if (_pauseListeners.Contains(pauseListener))
                    _pauseListeners.Remove(pauseListener);
        }
    }
}