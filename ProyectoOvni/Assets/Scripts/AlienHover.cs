using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienHover : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] BeamUp beam;

    [SerializeField] float deadZone = 0.1f;

    [SerializeField] float forwardAcc = 100.0f;
    [SerializeField] float backwardAcc = 25.0f;
                     float curr_Thrust = 0f;


    [SerializeField] float turnStrenght = 10.0f;
                     float curr_Turn = 0f;


   int layerMask;

    [SerializeField] float hoverForce = 0f;
    [SerializeField] float hoverHeight = 0f;
    [SerializeField] GameObject[] hoverPoints;

    [SerializeField] GameObject timerGO;
    public float timer;

    [SerializeField] GameManager gm;
    [SerializeField] GameObject puntosGO;
    public int puntos;






    void Start()
    {
        rb = GetComponent<Rigidbody>();

        layerMask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Cow") | 1 << LayerMask.NameToLayer("Beam") | 1 << LayerMask.NameToLayer("AreaDeDisparo");
        layerMask = ~layerMask;

        timer = timerGO.GetComponent<Timer>().currentTime;
        puntos = puntosGO.GetComponent<VacasUI>().numDeVacas;
    }

    // Update is called once per frame
    void Update()
    {

        timer = timerGO.GetComponent<Timer>().currentTime;

        //Acceleracion
        curr_Thrust = 0.0f;

        float aclAxis = Input.GetAxis("Vertical");
        //Si no esta usando el rayo se puede mover
        if (!beam.beamOn)
        {
            if (aclAxis > deadZone)
            {
                curr_Thrust = aclAxis * forwardAcc;
            }
            else if (aclAxis < -deadZone)
            {
                curr_Thrust = aclAxis * backwardAcc;
            }

        }

        


        //Giro
        curr_Turn = 0.0f;
        float turnAxis = Input.GetAxis("Horizontal");

        if (Mathf.Abs(turnAxis) > deadZone)
            curr_Turn = turnAxis;



    }


     void FixedUpdate()
    {

        /*var layerMask = (1 << 8 | 1 << 9 | 1 << 10 );
        layerMask = ~layerMask;*/

        //hover

        RaycastHit hit;
        for (int i = 0; i < hoverPoints.Length; i++)
        {
            var hoverPoint = hoverPoints[i];
            Debug.DrawRay(hoverPoint.transform.position, -Vector3.up, Color.red);
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, hoverHeight, layerMask))
            {
                
                rb.AddForceAtPosition(Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);
            }
            else
            {
                if(transform.position.y > hoverPoint.transform.position.y)
                {
                    rb.AddForceAtPosition(hoverPoint.transform.up * hoverForce, hoverPoint.transform.position);
                }
                else
                {
                    rb.AddForceAtPosition(hoverPoint.transform.up * -hoverForce, hoverPoint.transform.position);
                }
                

            }
        }


        //Forward
        if(Mathf.Abs(curr_Thrust) > 0){
            rb.AddForce(transform.forward * curr_Thrust);
        }

        //turn
        if(curr_Turn > 0)
        {
            rb.AddRelativeTorque(Vector3.up * curr_Turn * turnStrenght);
        }else if(curr_Turn < 0)
        {
            rb.AddRelativeTorque(Vector3.up * curr_Turn * turnStrenght);
        }

        if(timer <= 0)
        {
            hoverHeight++;

            if(hoverHeight > 500)
            {
                gm.GetComponent<GameManager>().LoadGameOver();
            }
        }

        if (puntos >= 5)
        {

            hoverHeight++;

            if (hoverHeight > 500)
            {
                gm.GetComponent<GameManager>().LoadWin();
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {

            if (beam.beamOn)
            {
                beam.beamOn = false;
            }
        }

    }
}
