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

    public float bastard_Speed;
    
    
    private void Start()
    {
        canFire = true;
    }
    void Update()
    {
        //faces the boss towards the player with turnSpeed controlling the rotation speed
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position, Vector3.up), rotationSpeed * Time.deltaTime);

        //fires a raycast to the player of length bossViewDistance to check if the player is detected
        //raycast is fired from the boss to the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, detectionRange))
        {
            if (hit.transform.tag == "Player" && canFire == true)
            {
                //if the player is detected, the boss will fire a projectile
                StartCoroutine(FireProjectile());

            }
            else
            {
                //move towards the player
                //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

        }
        
        // Stripper pole movement
        if (gameObject.transform.position.y < player.position.y)
        {
            Vector3 current_Position = transform.position;

            current_Position.y += bastard_Speed * Time.deltaTime;

            transform.position = current_Position;
        }
        else if (gameObject.transform.position.y > player.position.y)
        {
            Vector3 current_Position = transform.position;

            current_Position.y -= bastard_Speed * Time.deltaTime;

            transform.position = current_Position;
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
