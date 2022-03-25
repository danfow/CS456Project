using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliteEnemyMovement : MonoBehaviour
{
    public Transform player;
    private float speed = 30.0f;
    private float diveLimitZAxis;
    private float waitTime = 6.0f;
    private Vector3 pointA;
    private Vector3 pointB;

    public List<GameObject> movementPaths = new List<GameObject>();
    public Transform[] moveSpots;
    private int randomPath;
    private int index = 1;


    void Start()
    {
        player = GameObject.Find("Player Ship").GetComponent<Transform>();

        movementPaths.Add(GameObject.Find("Enemy Path 1"));
        movementPaths.Add(GameObject.Find("Enemy Path 2"));

        moveSpots = SetRandomPath();

        // spawn point
        this.transform.position = moveSpots[1].transform.position;

        diveLimitZAxis = player.position.z + 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (index < moveSpots.Length)
        {
            PathMovement();
        }
        else
        {
            if (waitTime <= 0)
            {
                Dive();
            }
            else
            {
                PingPongMovement();
                waitTime -= Time.deltaTime;
            }
        }

    }

    Transform[] SetRandomPath()
    {
        randomPath = Random.Range(0, 2);
        return movementPaths[randomPath].GetComponentsInChildren<Transform>();
    }

    void PathMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[index].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[index].position) < 0.1f)
        {

            index += 1;

        }
    }

    void PingPongMovement()
    {
        pointA = moveSpots[(moveSpots.Length - 1)].transform.position;
        pointB = moveSpots[(moveSpots.Length - 1)].transform.position + new Vector3(15, 0, 0);
        float time = Mathf.PingPong(Time.time + speed, 1);
        transform.position = Vector3.Lerp(pointB, pointA, time);
    }

    void Dive()
    {
        if (transform.position.z < diveLimitZAxis)
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}