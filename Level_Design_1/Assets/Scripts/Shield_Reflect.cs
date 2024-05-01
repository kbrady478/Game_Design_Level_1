using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Reflect : MonoBehaviour
{
    private string change_Projectile_Tag = "Player_Projectile";
    public Bastard Boss_Script;
    public GameObject projectile_Prefab;
    public GameObject projectile;
    
    public void Reflected_Spawn()
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
}
