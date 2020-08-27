using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _boxColour;

    //detect moving box
    //when close to centre
    //disable box's rigidbody or set it to kinematic
    //change colour of pressure pad to blue

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (other.tag == "MovingBox")
        {
            if (other.transform.position.x < .4f)
            {
                rb.isKinematic = true;
                _boxColour.material.color = Color.blue;
            }
        }
    }
}
