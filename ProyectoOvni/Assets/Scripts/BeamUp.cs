using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUp : MonoBehaviour
{

    [SerializeField] ParticleSystem particulas;
    [SerializeField] VacasUI vacasUI;
    //[SerializeField] GameObject cono;

    private Transform trans;
    [SerializeField] float transformVacaSpeed = 0.005f;
    public float pullRadius = 2;
    public float pullForce = 1;
    public bool vacaAbajo = false;
    public bool beamOn = false;

    private Vaca vacaActualScript;

    

    public float timer = 4f;

    public GameObject vacaActual = null;
    
    public Rigidbody vacaActualRB = null;

    public AudioClip beamClip;


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

                if (vacaActual.GetComponent<Rigidbody>())
                {
                    vacaActualRB = vacaActual.GetComponent<Rigidbody>();
                }
                else
                    vacaActualRB = null;



                print(vacaActual);
                vacaActualScript.rayoOn = true;
                

                if (timer <= 0)
                {
                    vacaActualRB.useGravity = false;

                    if (vacaActual.transform.localScale.x >= 0f)
                    {
                        vacaActual.transform.localScale -= new Vector3(transformVacaSpeed, transformVacaSpeed, transformVacaSpeed);
                    }

                    if (vacaActual.transform.localScale.x <= 0)
                    {
                        Destroy(vacaActual.gameObject);
                        vacaAbajo = false;

                        vacasUI.numDeVacas++;
                    }

                    beamPull();

                }
                else
                {
                    timer = timer - Time.deltaTime;
                }

                

            }

           if (!beamOn )
            {

              // vacaActualRB.useGravity = true;
                vacaActualScript.rayoOn = false;


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
            vacaActualScript = other.gameObject.GetComponent<Vaca>();
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
