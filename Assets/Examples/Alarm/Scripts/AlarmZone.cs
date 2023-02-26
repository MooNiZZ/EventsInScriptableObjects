using System;
using UnityEngine;

namespace Examples.Alarm.Scripts
{
    public class AlarmZone : MonoBehaviour
    {
        [SerializeField] private NotifyEnemyEvent _notifyEnemyEvent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _notifyEnemyEvent.Raise(other.transform.position);
            }
        }
    }
}
