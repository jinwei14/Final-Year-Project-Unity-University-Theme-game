using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//require class have rigid to attach to it
[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Use this for initialization contrain to collision
    private Rigidbody myRigidbody;


    private Vector3 moveVelocity;


    void Start()
    {
        //find the Rigidbody and refer to this player
        myRigidbody = GetComponent<Rigidbody>();

    }

    public void Move(Vector3 velocity)
    {
        moveVelocity = velocity;
    }

    public void LookAt(Vector3 pointToLook) {
        Vector3 lookInZPlane = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
        //the real point //need to rise to the Z axis
        transform.LookAt(lookInZPlane);
    }

    //normal by FPS fix will always happed 0.2 second
    //apply physics in here 
    void FixedUpdate()
    {
        //velocity times time between each fixed frame
        myRigidbody.MovePosition(myRigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }
}
