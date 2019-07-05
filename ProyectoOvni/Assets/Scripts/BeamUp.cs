﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUp : MonoBehaviour
{

    [SerializeField] ParticleSystem particulas;
    //[SerializeField] GameObject cono;

    private Transform trans;
    public float pullRadius = 2;
    public float pullForce = 1;
    public bool vacaAbajo = false;
    public bool beamOn = false;

    

    public float timer = 4f;

    public GameObject vacaActual = null;
    private Transform vacaActualTrans = null;
    public Rigidbody vacaActualRB = null;


    // [SerializeField] GameObject collider;



    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
     //   Collider conoCollider = cono.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print("Beam");
            particulas.Play();

            beamOn = true;
            vacaActualTrans = vacaActual.transform;




        }

        if (Input.GetButtonUp("Jump"))
        {
            print("Beam off");
            particulas.Stop();
            beamOn = false;
            timer = 4f;
        }

        
    }

    private void FixedUpdate()
    {

        if (vacaAbajo)
        {

            

            if (beamOn)
            {
                //var tamano = vacaActual.transform.localScale;


                vacaActualRB = vacaActual.GetComponent<Rigidbody>();

                print(vacaActual);

                if (timer <= 0)
                {
                    vacaActualRB.useGravity = false;

                    if (vacaActual.transform.localScale.x >= 0f)
                    {
                        vacaActual.transform.localScale -= new Vector3(0.005F, 0.005f, 0.005f);
                    }
                    
                    beamPull();

                }
                else
                {
                    timer = timer - Time.deltaTime;
                }

                

            }

            if (!beamOn && !vacaActualRB.useGravity)
            {

                vacaActualRB.useGravity = true;
                vacaActualTrans = null;


            }
            else if (!beamOn && vacaActual.transform.localScale.x < vacaActual.transform.localScale.x)
            {
                vacaActual.transform.localScale += new Vector3(0.05F, 0.05f, 0.05f);
            }

            
            


        }


        

        
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Vaca>())
        {
            vacaAbajo = true;

            print(other + " trigger");

            vacaActual = other.gameObject;
        }

        

        
        

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Vaca>())
        {
            vacaAbajo = false;
            print(other + " trigger out");

            vacaActual = null;
        }
        
    }

    private void beamPull()
    {
        float step = pullForce * Time.deltaTime;
        vacaActual.transform.position = Vector3.Lerp(vacaActual.transform.position, transform.position, step);
    }







}
