using System;
using UnityEngine;

namespace DemoGameplay
{
    [RequireComponent(typeof(Transform))]
    public sealed class MovableComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        
        [SerializeField]
        private float _speed;

        private void OnValidate()
        {
            _transform = transform;
        }

        public void Move(Vector3 direction)
        {
            _transform.position += direction * (_speed * Time.deltaTime);
        }
    }
}