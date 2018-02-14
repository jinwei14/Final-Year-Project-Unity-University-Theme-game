using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //give a speed to the bullet
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //tell the object to go to the new position
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
