using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;
    [SerializeField]
    private int _requiredCoins = 8;
    
    //check collision
    //check player
    //if e key is pressed
    //turn light to blue

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CointCount() >= _requiredCoins)
            {
                _callButton.material.color = Color.green;
            }
        }
    }
}
