using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Examples.Alarm.Scripts
{
    public class EnemyScript : MonoBehaviour
    {

        [SerializeField] private NotifyEnemyEvent _onNotifyEnemyEvent;

        [SerializeField] private float _movementSpeed;
        private float _movementDelta;
        private Vector3 _targetPosition;
        private bool _hasTarget;

        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void OnEnable()
        {
            _onNotifyEnemyEvent.AddListener(OnNotifyEnemy);
        }

        private void OnDisable()
        {
            _onNotifyEnemyEvent.RemoveListener(OnNotifyEnemy);
        }

        private void OnNotifyEnemy(Vector3 position)
        {
            _hasTarget = true;
            _targetPosition = position;
        }

        private void Update()
        {
            if (!_hasTarget)
                return;
            
            _movementDelta = _movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementDelta);

            if (Vector3.Distance(transform.position, _targetPosition) < _movementDelta)
            {
                if (_targetPosition == _startPosition)
                {
                    _hasTarget = false;
                }
                _targetPosition = _startPosition;
                
            } 
        }
    }
}
