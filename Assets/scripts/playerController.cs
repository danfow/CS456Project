using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 75.0f;
    public float horizontalInput;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //playerRb.MovePosition( transform.position + Vector3.right * speed * horizontalInput);
        Vector3 moveSide = (horizontalInput * transform.right);
        playerRb.AddForce((moveSide * speed) - playerRb.velocity, ForceMode.VelocityChange);

    }
}
