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

    private float nextAttackTime = 0f; //time at which the enemy can attack again

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
                }
            }
            else
            {
                //move towards the player
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
 }

