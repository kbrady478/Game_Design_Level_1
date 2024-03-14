using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player_Shield : MonoBehaviour
{
    public float energy_Pool = 100;
    private bool shield_Toggle;
    public float recharge_Rate;
    public float consumption_Rate;
    public float recharge_Delay;
    
    public Shield_Reflect reflect_Script;
    public GameObject repulsor_Shield;
    
    public TextMeshProUGUI energy_Meter_UI;
    
    //private Coroutine recharge_Delay_Coroutine;
    //private Coroutine recharger_Coroutine;
    private void Start()
    {
        if (repulsor_Shield.activeInHierarchy == true)
        {
            repulsor_Shield.SetActive(false);
        }

    }// end Start()

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Right) && energy_Pool > 1)
        {
            shield_Toggle = Shield_On();
            
        }
        else if (Input.GetMouseButtonUp((int)MouseButton.Right) || energy_Pool < 1 && energy_Pool != 0.5)
        {
            
            Shield_Off(); 
        }
        else
        {
            StartCoroutine(energy_Recharger());
        }

        if (shield_Toggle == true)
        {
            energy_Pool -= consumption_Rate * Time.deltaTime;
        }

        if (energy_Pool > 100)
        {
            energy_Pool = 100;
        }
        if (energy_Pool < 0)
        {
            energy_Pool = 0;
        }
        
        //print(energy_Pool);
        
        // set ui element
        energy_Meter_UI.text = "" + Mathf.RoundToInt(energy_Pool);
        
    }// end Update()


    private bool Shield_On()
    {
        print("shield on"); 
        repulsor_Shield.SetActive(true);
        energy_Pool -= consumption_Rate;
        // To stop energy recharge while shield is on
        StopAllCoroutines();
        return true;
    }// end Shield_On()

    private bool Shield_Off()
    {
        print("shield off");
        repulsor_Shield.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(energy_Recharger());
        
        shield_Toggle = false;
        return true;
    }// end Shield_Off()


    IEnumerator energy_Recharger()
    {
        if (energy_Pool < 1)
            energy_Pool = 0.5f;
        if (shield_Toggle != true)
        {
            yield return new WaitForSeconds(recharge_Delay);
            if (energy_Pool < 100)
            {
                energy_Pool += recharge_Rate * Time.deltaTime;
            }
        }

    }// end energy_Recharger()
       
    public void Reflect_Projectile()
    {
        reflect_Script.Reflected_Spawn();
    }// end Reflect_Projectile()
    
}// end Player_Shield
