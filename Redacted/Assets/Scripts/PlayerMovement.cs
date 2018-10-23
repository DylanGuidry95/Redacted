using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    private void Update()
    {        
        float rot = Input.GetAxis("Mouse X");

        if(Input.GetKey(KeyCode.W))
            transform.position += transform.forward * (MovementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * (MovementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.position += -transform.right * (MovementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * (MovementSpeed * Time.deltaTime);
        transform.Rotate(transform.up, rot);
    }
}
