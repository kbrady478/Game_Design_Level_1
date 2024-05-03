using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretdestroy : MonoBehaviour
{
    GameObject turret;
    private void Start()
    {
        turret = GameObject.Find("Projectile Boss");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player_Projectile")
        {
            Destroy(turret);
        }
    }
}
