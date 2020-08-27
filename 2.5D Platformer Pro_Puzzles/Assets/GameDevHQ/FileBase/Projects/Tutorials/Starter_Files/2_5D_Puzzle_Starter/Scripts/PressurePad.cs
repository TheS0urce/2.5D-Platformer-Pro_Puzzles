using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    //detect moving box
    //when close to centre
    //disable box's rigidbody or set it to kinematic
    //change colour of pressure pad to blue

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MovingBox")
        {
            float distance = Vector2.Distance(transform.position, other.transform.position);

            if (distance < .2f)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
                MeshRenderer mr = other.GetComponent<MeshRenderer>();

                if(renderer != null)
                {
                    renderer.material.color = Color.blue;
                }

                if(mr != null)
                {
                    mr.material.color = Color.grey;
                }

                Destroy(this);
            }
        }
    }
}
