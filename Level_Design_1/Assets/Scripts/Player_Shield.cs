using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    private string change_Projectile_Tag = "Player_Projectile";
    
    public GameObject projectile_Prefab;
    public LevelDesignProjectileBossPrefab Boss_Script;
    //private bool shield_Toggle = false;
    public GameObject repulsor_Shield;
    public GameObject projectile;

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
        //shield_Toggle = true;


    }// end Shield_On()

    private void Shield_Off()
    {
        print("shield off");
        repulsor_Shield.SetActive(false);
        //shield_Toggle = false;
    }// end Shield_Off()

    public void Reflect_Projectile()
    {
        Debug.Log("Projectile Reflected");
        //creates a new projectile
        GameObject projectile = Instantiate(projectile_Prefab);
        projectile.tag = change_Projectile_Tag;
        //sets the projectile's position and rotation to the boss's position and rotation
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        projectile.GetComponent<LevelDesignProjectilePrefab>().projectileSpeed = Boss_Script.projectileSpeed;
        projectile.GetComponent<LevelDesignProjectilePrefab>().projectileImpactRadius = Boss_Script.projectileImpactRadius;
        projectile.GetComponent<LevelDesignProjectilePrefab>().projectileLifetime = Boss_Script.projectileLifetime;
    }// end Reflect_Projectile
    
}// end Player_Shield
