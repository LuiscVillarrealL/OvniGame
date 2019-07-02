using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUp : MonoBehaviour
{

    [SerializeField] ParticleSystem particulas;

    private Transform trans;
    public float pullRadius = 2;
    public float pullForce = 1;

    

    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print("Spcae");
            particulas.Play();


            
        }

        if (Input.GetButtonUp("Jump"))
        {
            particulas.Stop();
        }

        
    }





}
