using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacasUI : MonoBehaviour
{

    public int numDeVacas;

    [SerializeField] Image[] vacas;

    [SerializeField] Sprite vacaSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vacas.Length; i++)
        {
            if (i < numDeVacas)
            {
                vacas[i].enabled = true;
            }
            else
                vacas[i].enabled = false;
        }
    }
}
