using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    //private bool shield_Toggle = false;
    public GameObject repulsor_Shield;
    public GameObject projectile;

    private void Start()
    {
        if (repulsor_Shield.activeInHierarchy == true)
        {
           // repulsor_Shield.SetActive(false);
        }
    }// end Start()

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Right))
        {
            Shield_On();
        }

        if (Input.GetMouseButtonUp((int)MouseButton.Right))
        {
            Shield_Off();
        }
    }// end Update()

    private void OnCollisionEnter(Collision collided)
    {

        if (collided.gameObject.CompareTag("Bastard_Projectile"))
        {
            Destroy(gameObject);
            print("projectile blocked");
        }
    }

    private void Shield_On()
    {
        print("shield on"); 
        repulsor_Shield.SetActive(true);
        //shield_Toggle = true;


    }// end Shield_On()

    private void Shield_Off()
    {
        print("shield off");
        repulsor_Shield.SetActive(false);
        //shield_Toggle = false;
    }// end Shield_Off()
    
}// end Player_Shield
