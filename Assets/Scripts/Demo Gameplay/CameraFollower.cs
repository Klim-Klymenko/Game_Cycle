using System;
using GameCycle;
using UnityEngine;

namespace DemoGameplay
{
    [RequireComponent(typeof(Transform))]
    public sealed class CameraFollower : MonoBehaviour, ILateUpdateGameListener
    {
        [SerializeField]
        private Transform _targetTransform;
        
        [SerializeField]
        private Transform _followTransform;
        
        [SerializeField]
        private Vector3 _offset;

        private void OnValidate()
        {
            _followTransform = transform;
        }

        void ILateUpdateGameListener.OnLateUpdate()
        {
            _followTransform.position = _targetTransform.TransformPoint(_offset);
        }
    }
}