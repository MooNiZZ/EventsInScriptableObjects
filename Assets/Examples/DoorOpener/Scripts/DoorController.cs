using System;
using UnityEngine;

namespace Examples.DoorOpener.Scripts
{
    public class DoorController : MonoBehaviour
    {
        public enum DoorState
        {
            Open,
            Closed
        }
        [SerializeField] private BoolEvent _onOpenDoorEvent;
        [SerializeField] private DoorState _doorState = DoorState.Closed;
        [SerializeField] private float _doorOpenDuration = 1;

        [SerializeField] private float _zRotationOpen;
        [SerializeField] private float _zRotationClosed;

        private Vector3 _targetRotation;
        
        private float _doorTimer = 0;
        private float _angle;
        private bool _isActive;

        private void OnEnable()
        {
            _onOpenDoorEvent.AddListener(OnOpenDoor);
        }
        private void OnDisable()
        {
            _onOpenDoorEvent.RemoveListener(OnOpenDoor);
        }

        private void OnOpenDoor(bool open)
        {
            if (_isActive)
            {
                // If we change the state while we're active
                // We can't reset the timer since it would rotate for too long
                // So we if the timer is 1.4s and duration is 2s, we have 0.6s left and set _doorTimer to 0.6s to have 1.4s left
                _doorTimer = _doorOpenDuration - _doorTimer;
            }
            if (open)
            {
                TryOpenDoor();
            }
            else
            {
                TryCloseDoor();
            }
        }

        private void TryCloseDoor()
        {
            // If we're closed, no need to close it again!
            if (_doorState == DoorState.Closed)
                return;

            _doorState = DoorState.Closed;
            _isActive = true;
            _targetRotation = new Vector3(0,0, _zRotationClosed);
            _angle = _zRotationClosed - _zRotationOpen;
        }

        private void TryOpenDoor()
        {
            // If we're closed, no need to open it again!
            if (_doorState == DoorState.Open)
                return;
            _isActive = true;
            
            _doorState = DoorState.Open;
            _targetRotation = new Vector3(0,0, _zRotationOpen);
            _angle = _zRotationOpen - _zRotationClosed;

            
        }

        private void Update()
        {
            if (!_isActive)
                return;

            _doorTimer += Time.deltaTime;
            
            transform.Rotate(Vector3.forward, _angle / _doorOpenDuration * Time.deltaTime );

            if (_doorTimer >= _doorOpenDuration)
            {
                transform.rotation = Quaternion.Euler(_targetRotation);
                _doorTimer = 0;
                _isActive = false;
            }
            
        }
    }
}
