using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float forceRotation = 100f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 450f;
    float xValue = 0f;
    float yValue = 0f;
    float zValue = 0f;

    Rigidbody rigidbody;
    AudioSource audio;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {   
        xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPlayer();
        }
           
    }

    void JumpPlayer()
    {
        transform.Translate(0, Time.deltaTime * jumpForce, 0);
    }
}
