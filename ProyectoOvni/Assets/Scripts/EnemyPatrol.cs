using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    private Quaternion rotation;

    public bool alienInView;


    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        //rotation = Quaternion.LookRotation(moveSpots[randomSpot].position);

        // transform.rotation = rotation;

        // transform.LookAt(moveSpots[randomSpot].position);


        

        if (moveSpots[randomSpot].position != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            var q = Quaternion.LookRotation(moveSpots[randomSpot].position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, speed * Time.deltaTime);
        }
        

        

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {



        }
    }


    void OnTriggerEnter(Collider other)
    {
        print("tanque toco = " + other.gameObject);
    }


}
