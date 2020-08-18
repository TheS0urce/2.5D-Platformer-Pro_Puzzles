using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    [SerializeField]
    private float _elevatorSpeed = 5.0f;
    [SerializeField]
    private bool _elevatorDown = false;

    public void CallElevator()
    {
        //know position of the elevator

        _elevatorDown = !_elevatorDown;
        
    }

    void FixedUpdate()
    {
        //going down == true
        //move.towards target position a
        //else
        //reverse

        if (_elevatorDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _elevatorSpeed * Time.deltaTime);
        }

        else if(_elevatorDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _elevatorSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
