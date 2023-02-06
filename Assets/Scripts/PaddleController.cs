using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{   
    public float unitsPerSecond = 3f;
    // Start is called before the first frame update
    public Rigidbody leftPaddle; //I'm not entirely sure about this method
    public Rigidbody rightPaddle;


    void Start()
    {
        
    }
    
    //every 10ms
    private void FixedUpdate(){
        //moving each paddle
        float horizontalValue = Input.GetAxis("Right Paddle");
        Vector3 force = Vector3.right * horizontalValue;
        rightPaddle.AddForce(force, ForceMode.Force);

        horizontalValue = Input.GetAxis("Left Paddle");
        force = Vector3.right * horizontalValue;
        leftPaddle.AddForce(force, ForceMode.Force);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {   
        // BoxCollider bc = GetComponent<BoxCollider>();
        // Bounds bounds = bc.bounds;
        // float maxX = bounds.max.x;
        // float maxY = bounds.max.y;

        // Quaternion rotation = Quaternion.Euler(0f,0f,60f);
        // Vector3 bounceDirection = rotation * Vector3.up;


        // Rigidbody rb = collision.rigidbody;
        // rb.AddForce(bounceDirection * 1000f, ForceMode.Force);

    }
}