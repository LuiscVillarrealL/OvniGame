using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 playerPos;
    public Vector3 playerPosIn;
    public float speed = 50f;
    public Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        playerPosIn = playerPos;
        rb.velocity = ((playerPosIn - transform.position).normalized * speed);

    }

   

    // Update is called once per frame
    void Update()
    {

        

       // rb.AddForce(Vector3.forward * speed);
    }


    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
