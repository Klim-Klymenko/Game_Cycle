using GameCycle;
using UnityEngine;

namespace DemoGameplay
{
    public sealed class InputMoveController : MonoBehaviour, IUpdateGameListener
    {
        [SerializeField]
        private MovableComponent _movableComponent;
        
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        void IUpdateGameListener.OnUpdate()
        {
            float horizontal = Input.GetAxis(HorizontalAxis);
            float vertical = Input.GetAxis(VerticalAxis);
            
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
            _movableComponent.Move(direction);
        }
    }
}