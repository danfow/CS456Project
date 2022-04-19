using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 75.0f;
    public float horizontalInput;
    private Rigidbody playerRb;
    public GameObject playerLaser;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && gameManager.status == false)
        {
            Instantiate(playerLaser, transform.position, playerLaser.transform.rotation);
        }
       if (gameManager.status == true)
        {
            speed = 0.0f;
        }
        
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //playerRb.MovePosition( transform.position + Vector3.right * speed * horizontalInput);
        Vector3 moveSide = (horizontalInput * transform.right);
        playerRb.AddForce((moveSide * speed) - playerRb.velocity, ForceMode.VelocityChange);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You got hit by an enemy ship. You lose!");
            Destroy(collision.gameObject);
            gameManager.UpdateLives(-1);

        }
    }
}
