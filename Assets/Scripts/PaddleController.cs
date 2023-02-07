using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{   
    public float unitsPerSecond = 3f;
    // Start is called before the first frame update
    public Rigidbody leftPaddle; //I'm not entirely sure about this method
    public Rigidbody rightPaddle;
    private Vector3 shrinkPaddle;



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
        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;

        // Debug.Log($"1: {(collision.gameObject.transform.position.x-minX)}");
        // Debug.Log($"2: {(maxX-minX)}");
        // Debug.Log($"3: {((collision.gameObject.transform.position.x-minX)/(maxX-minX))}");
        // Debug.Log($"Works: {(((collision.gameObject.transform.position.x-minX)/(maxX-minX))-(0.5f))}");

        //Quaternion rotation = Quaternion.Euler( 0f, 60f * (((collision.gameObject.transform.position.x-minX)/(maxX-minX))-(0.5f)), 0f);

        Vector3 bounceDirection = Vector3.forward;
        shrinkPaddle = new Vector3(-0.5f, 0.0f, 0.0f);

        if(collision.gameObject.transform.position.z > 0){
            bounceDirection = Quaternion.Euler( 0f, -60f * (((collision.gameObject.transform.position.x-minX)/(maxX-minX))-(0.5f)), 0f) * Vector3.back;
            if(leftPaddle.transform.localScale.x > 2){
                leftPaddle.transform.localScale += shrinkPaddle;
            }
        } else if (collision.gameObject.transform.position.z < 0){
            bounceDirection = Quaternion.Euler( 0f, 60f * (((collision.gameObject.transform.position.x-minX)/(maxX-minX))-(0.5f)), 0f) * Vector3.forward;

            if(rightPaddle.transform.localScale.x > 2){
                rightPaddle.transform.localScale += shrinkPaddle;
            }
        }

        collision.rigidbody.AddForce(bounceDirection * 1000f, ForceMode.Force);

    }


}