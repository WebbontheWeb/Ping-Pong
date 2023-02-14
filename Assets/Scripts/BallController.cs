using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{   
    private Vector3 shrinkPaddle;
    private int rightScore = 0;
    private int leftScore = 0;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public Rigidbody leftPaddle; //I'm not entirely sure about this method
    public Rigidbody rightPaddle;


    

    // Start is called before the first frame update
    void Start()
    {   
        //WaitForSeconds
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = Vector3.back * 1000;
        rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        //rightScoreText.color = Color.black;
        //leftScoreText.color = Color.black;
    }

    void OnTriggerEnter(Collider other) 
	{   
        Rigidbody rb = GetComponent<Rigidbody>();
		if (other.gameObject.name == "Top PowerUp"){
            if(rb.velocity.z > 0){
                rightPaddle.transform.localScale = new Vector3(15f, 1f, 1f);
            } else {
                leftPaddle.transform.localScale = new Vector3(15f, 1f, 1f);
            }
        } else if (other.gameObject.name == "Lower PowerUp"){
            if(rb.velocity.z > 0){
                leftPaddle.transform.localScale = new Vector3(3f, 1f, 1f);
            } else {
                rightPaddle.transform.localScale = new Vector3(3f, 1f, 1f);
            }
        }
	}
    private void OnCollisionEnter(Collision collision)
    {   
        //could be cleaned up
        // if (collision.gameObject.name == "Right Paddle")
        // {   
        //     BoxCollider bc = collision.gameObject.GetComponent<BoxCollider>();
        //     Bounds bounds = bc.bounds;
        //     float maxX = bounds.max.x;
        //     float minX = bounds.min.x;

        //     Quaternion rotation = Quaternion.Euler( 0f, 0f, 60f * (collision.gameObject.transform.position.x-minX/maxX-minX));
            
        //     Vector3 bounceDirection = rotation * Vector3.forward;

        //     Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //     rb.AddForce(bounceDirection * 2000f, ForceMode.Force);
        //     shrinkPaddle = new Vector3(-1f, 0.0f, 0.0f);
        //     collision.gameObject.transform.localScale += shrinkPaddle;
        // }  else if (collision.gameObject.name == "Left Paddle"){
        //     BoxCollider bc = collision.gameObject.GetComponent<BoxCollider>();
        //     Bounds bounds = bc.bounds;
        //     float maxX = bounds.max.x;
        //     float minX = bounds.min.x;

        //     Quaternion rotation = Quaternion.Euler(60f, 60f, 60f);
            
        //     Vector3 bounceDirection = rotation * Vector3.back;

        //     Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //     rb.AddForce(bounceDirection * 2000f, ForceMode.Force);
        //     shrinkPaddle = new Vector3(-1f, 0.0f, 0.0f);
        //     collision.gameObject.transform.localScale += shrinkPaddle;
        // }

        //there's gotta be a better way to do this, but I have no clue what
        //it might be
        Rigidbody rb = GetComponent<Rigidbody>();
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
        Vector3 force = Vector3.forward;

        if (collision.gameObject.name == "Upper Wall"){
            force = Vector3.left;
            if(rb.velocity.z > 0){
                rotation = Quaternion.Euler(0f, 45f, 0f);
            } else {
                rotation = Quaternion.Euler(0f, -45f, 0f);
            }
            rb.AddForce((rotation * force) * 750f, ForceMode.Force);
        } else if(collision.gameObject.name == "Lower Wall"){
            force = Vector3.right;
            if(rb.velocity.z > 0){
                rotation = Quaternion.Euler(0f, -45f, 0f);
            } else {
                rotation = Quaternion.Euler(0f, 45f, 0f);
            }
            rb.AddForce((rotation * force) * 750f, ForceMode.Force);
        } else if(collision.gameObject.name == "Left Wall"){
            rightScore++;
            Debug.Log($"Right Scores! {leftScore}-{rightScore}");
            rightScoreText.color = Color.red;
            leftScoreText.color = Color.black;            leftScoreText.color = Color.black;
            rightScoreText.text = $"{rightScore}";

            rb.transform.position = new Vector3(0f, 0f, 0f);

            rightPaddle.transform.localScale = new Vector3(8f, 1f, 1f);
            leftPaddle.transform.localScale = new Vector3(8f, 1f, 1f);

            force = Vector3.back * 500;
            rb.AddForce(force, ForceMode.Force);
        } else if(collision.gameObject.name == "Right Wall"){
            leftScore++;
            Debug.Log($"Left Scores! {leftScore}-{rightScore}");
            leftScoreText.text = $"{leftScore}";
            rightScoreText.color = Color.black;
            leftScoreText.color = Color.blue;

            rb.transform.position = new Vector3(0f, 0f, 0f);

            rightPaddle.transform.localScale = new Vector3(8f, 1f, 1f);
            leftPaddle.transform.localScale = new Vector3(8f, 1f, 1f);

            force = Vector3.forward * 500;
            rb.AddForce(force, ForceMode.Force);
        } 

        if(leftScore > 9){
            Debug.Log($"Game Over, Left Paddle Wins");
            rightScore = 0;
            leftScore = 0;
            rightScoreText.text = $"{rightScore}";
            leftScoreText.text = $"{leftScore}";
        } else if (rightScore > 9){
            Debug.Log($"Game Over, Right Paddle Wins");
            rightScore = 0;
            leftScore = 0;
            rightScoreText.text = $"{rightScore}";
            leftScoreText.text = $"{leftScore}";
        }





    }


}
