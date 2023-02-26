using UnityEngine;

namespace Examples.Alarm.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
            var _movementDirection = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                _movementDirection += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementDirection += Vector2.right;
            }
        
            if (Input.GetKey(KeyCode.W))
            {
                _movementDirection += Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementDirection += Vector2.down;
            }

            transform.position += (Vector3)_movementDirection * (Time.deltaTime * _movementSpeed);
        }
    }
}
