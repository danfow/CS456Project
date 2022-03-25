using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDown : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    public float laserSpeed = 5f;
    void Start()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * laserSpeed * Time.deltaTime);

        if(transform.position.z < -40)
        {
            Destroy(gameObject); //these bootleg lasers are def not performance friendly so we want to delete them as soon as they are off screen!
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You got hit by a laser! you lose!");
        }
    }
}
