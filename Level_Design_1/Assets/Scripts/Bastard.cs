using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bastard : MonoBehaviour
{
    public float speed = 5f; //speed at which the boss flies
    public float rotationSpeed = 5f; //speed at which the boss rotates
    public float detectionRange = 10f; //distance at which the boss can detect the player
    public float stareRange = 5f; //distance at which the boss must stare at the player, this is to prevent him floating into the player


    public Transform player; //reference to the player's transform

    public bool canFire;
    public Transform shootPoint; //reference to the boss' projectile instantiation point
    public GameObject projectilePrefab; //reference to the bullet shot by the boss
    public float projectileSpeed;
    public float projectileLifetime;
    public float projectileCount;
    public float projectileImpactRadius;
    public float fireCooldown;
    public float projectileCooldown;

    private void Start()
    {
        canFire = true;
    }
    void Update()
    {
        //check if the player is within detection range
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            //rotate towards the player
            Vector3 direction = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            //check if the player is within stare range
            if (Vector3.Distance(transform.position, player.position) < stareRange)
            {
                
                //check if the enemy can attack again
                if (Time.time > fireCooldown)
                {
                    StartCoroutine(FireProjectile());
                    //start attacking
                }
            }
            else
            {
                //move towards the player
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
    IEnumerator FireProjectile()
    {
        canFire = false;
        //fires a projectileCount amount of projectiles
        for (int i = 0; i < projectileCount; i++)
        {
            //creates a new projectile
            GameObject projectile = Instantiate(projectilePrefab);
            //sets the projectile's position and rotation to the boss's position and rotation
            projectile.transform.position = shootPoint.position;
            projectile.transform.rotation = shootPoint.rotation;
            projectile.GetComponent<LevelDesignProjectilePrefab>().projectileSpeed = projectileSpeed;
            projectile.GetComponent<LevelDesignProjectilePrefab>().projectileImpactRadius = projectileImpactRadius;
            projectile.GetComponent<LevelDesignProjectilePrefab>().projectileLifetime = projectileLifetime;
            //waits for projectileCooldown amount of time before firing the next projectile
            yield return new WaitForSeconds(projectileCooldown);
        }
        //waits for fireCooldown amount of time before the boss can fire again
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }
}
