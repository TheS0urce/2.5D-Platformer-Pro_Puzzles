using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;
    [SerializeField]
    private int _requiredCoins = 8;
    
    public bool elevatorCalled = false;

    private Elevator _elevator;
    private bool _elevatorCalled = false;

    //check collision
    //check player
    //if e key is pressed
    //turn light to blue

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if(_elevator == null)
        {
            Debug.LogError("Elevator is NULL");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CointCount() >= _requiredCoins)
            {

                if(_elevatorCalled == true)
                {
                    _callButton.material.color = Color.red;
                }
                else if (_elevatorCalled == false)
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;
                }
                
                _elevator.CallElevator();
            }
        }
    }
}
