using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    private float horizontalInput;
    public bool isOnGround = true;

    public float jumpforce = 5.0f;
    private float forwardInput;

    private Rigidbody playerRb;
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // using these lines to get player input
        forwardInput=Input.GetAxis("Vertical");

        
        transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput); // using these lines to move the player 
        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space)&&isOnGround)  //To make a player jump
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); 
            isOnGround=false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
