using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiser : MonoBehaviour
{
    [SerializeField] private BoolEvent _openDoorEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _openDoorEvent.Raise(true);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _openDoorEvent.Raise(false);
        }
    }
}
