using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed;
    private float diveLimitZAxis;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int index = 0;


    void Start()
    {
        waitTime = startWaitTime;
        diveLimitZAxis = player.position.z + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, moveSpots[index].position, speed * Time.deltaTime);
        if(index < moveSpots.Length)
        {
            PathMovement();
        }
        else
        {
            Dive();
        }

    }

    void PathMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[index].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[index].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                index += 1;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Dive()
    {
        if(transform.position.z < diveLimitZAxis)
        {
            transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
