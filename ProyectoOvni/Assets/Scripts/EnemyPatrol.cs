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
    public GameObject player;


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





        /*


     if (alienInView)
     {
         var q = Quaternion.LookRotation(player.transform.position - transform.position);
         transform.rotation = Quaternion.RotateTowards(transform.rotation, q, speed * Time.deltaTime);
         transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
     }
     else
     {
         var q = Quaternion.LookRotation(moveSpots[randomSpot].position - transform.position);
         transform.rotation = Quaternion.RotateTowards(transform.rotation, q, speed * Time.deltaTime);
         transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
     }

     */
        var q = Quaternion.LookRotation(moveSpots[randomSpot].position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);



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

        print(other);

        if (other.gameObject.GetComponentInParent<AlienHover>())
        {
            alienInView = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<AlienHover>())
        {
            alienInView = false;
        }
    }


}
