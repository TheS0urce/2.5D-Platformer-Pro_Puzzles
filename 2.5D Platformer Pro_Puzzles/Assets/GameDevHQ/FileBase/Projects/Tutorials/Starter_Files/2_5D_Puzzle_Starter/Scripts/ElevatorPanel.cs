using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;
    
    //check collision
    //check player
    //if e key is pressed
    //turn light to blue

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _callButton.material.color = Color.green;
            }
        }
    }
}
