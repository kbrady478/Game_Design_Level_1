using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bastard : MonoBehaviour
{
    public float speed = 5f; //speed at which the enemy flies
    public float rotationSpeed = 5f; //speed at which the enemy rotates
    public float detectionRange = 10f; //distance at which the enemy can detect the player
    public float attackRange = 5f; //distance at which the enemy can attack the player
    public float attackCooldown = 2f; //time between each attack
    public int attackDamage = 10; //amount of damage the enemy inflicts on the player
    public Transform player; //reference to the player's transform
    public float projectileSpeed;
    public float projectileLifetime;
    public float projectileImpactRadius;
    public float projectileCooldown;
    public float projectileCount;
    public float fireCooldown;
    public bool canFire;
    public GameObject projectilePrefab;
    private float nextAttackTime = 0f; //time at which the enemy can attack again


    void Start()
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

            //check if the player is within attack range
            if (Vector3.Distance(transform.position, player.position) < attackRange)
            {
                //check if the enemy can attack again
                if (Time.time > nextAttackTime)
                {
                    //start attacking
                    StartCoroutine(FireProjectile());
                    Debug.Log("SHOOT");
                }
            }
            else
            {
                //move towards the player
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation;
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
 }

