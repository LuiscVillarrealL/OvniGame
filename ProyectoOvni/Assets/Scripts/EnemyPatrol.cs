using System;
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
    public int counterPos = 0;

    public float fireRate = 1f;
    public float fireCountdown = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 50;



    public bool alienInView;
    public GameObject player;


    private void Start()
    {
        waitTime = startWaitTime;
        counterPos = 0;
       // randomSpot = Random.Range(0, moveSpots.Length);
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

         if (!alienInView)
         {
             var q = Quaternion.LookRotation(moveSpots[counterPos].position - transform.position);
             transform.rotation = Quaternion.RotateTowards(transform.rotation, q, speed * Time.deltaTime);


             transform.position = Vector3.MoveTowards(transform.position, moveSpots[counterPos].position, speed * Time.deltaTime);

           

             if (Vector3.Distance(transform.position, moveSpots[counterPos].position) < 0.2f)
             {
                 counterPos++;
                 if (waitTime <= 0)
                 {

                     waitTime = startWaitTime;
                 }
                 else
                 {
                     waitTime -= Time.deltaTime;
                 }

                 if (counterPos >= moveSpots.Length)
                 {
                     counterPos = 0;
                 }
             }

         }
         else{
             var q = Quaternion.LookRotation(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, speed * Time.deltaTime);

           if (fireCountdown <= 0f)
           {
               Shoot();
               fireCountdown = 1f / fireRate;
           }

           fireCountdown -= Time.deltaTime;

         }

   

        

    }

    private void Shoot()
    {
        var playerpos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity) as GameObject;
        Bullet bScript = bullet.GetComponent<Bullet>();

        bScript.playerPos = playerpos;
      //  bRb.velocity();
        
    }

    void OnTriggerEnter(Collider other)
    {



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
