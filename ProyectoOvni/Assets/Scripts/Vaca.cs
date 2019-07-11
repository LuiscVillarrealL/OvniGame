using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca : MonoBehaviour
{

    public bool areaDeRayo = false;
    public bool rayoOn = false;

    [SerializeField] float transformSpeed = 0.005f;
    private Vector3 tamanoOriginal;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        tamanoOriginal = transform.localScale;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.localScale.x < tamanoOriginal.x && !rayoOn || (transform.localScale.x < tamanoOriginal.x && !areaDeRayo))
        {

            transform.localScale += new Vector3(transformSpeed, transformSpeed, transformSpeed);
            rb.useGravity = true;
        }

       /* if (!areaDeRayo && !rb.useGravity)
        {
            rb.useGravity = true;
        }*/


       /* if(transform.localScale.x <= 0)
        {
            Destroy(this.gameObject);
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {


        print("Collider de vaca toco a " + other);

        areaDeRayo = true;



    }

    private void OnTriggerExit(Collider other)
    {
        areaDeRayo = false;


        print("Collider de vaca salio de " + other);
    }
}
