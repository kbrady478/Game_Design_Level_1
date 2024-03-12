using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    public Shield_Reflect reflect_Script;
    public GameObject repulsor_Shield;
    
    
    private void Start()
    {
        if (repulsor_Shield.activeInHierarchy == true)
        {
           repulsor_Shield.SetActive(false);
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

    private void Shield_On()
    {
        print("shield on"); 
        repulsor_Shield.SetActive(true);
    }// end Shield_On()

    private void Shield_Off()
    {
        print("shield off");
        repulsor_Shield.SetActive(false);
    }// end Shield_Off()

    public void Reflect_Projectile()
    {
        reflect_Script.Reflected_Spawn();
    }// end Reflect_Projectile()
    
}// end Player_Shield
