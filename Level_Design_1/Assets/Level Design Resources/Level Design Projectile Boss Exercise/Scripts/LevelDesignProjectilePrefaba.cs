using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelDesignProjectilePrefab : MonoBehaviour
{
    private Player_Shield shield_Script;
    
    public float projectileSpeed;
    public float projectileImpactRadius;
    public float projectileLifetime;

    public GameObject explosionVisuals;
    // Start is called before the first frame update
    void Start()
    {
        shield_Script = FindObjectOfType<Player_Shield>();
        
        //destroys the projectile after projectileLifetime amount of time
        Destroy(gameObject, projectileLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //moves the projectile forward
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }
    //checks if the projectile collides with an object
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player_Projectile")
        {
            if (other.tag == "boss")
            {
                Debug.Log("bastard hit");
                Explode();
            }
        }
        else
        {
            if (other.tag != "Boss" && other.tag != "Shield" && other.tag != "Player_Projectile")
            {
                print("hit");
                //if the projectile collides with an object, it will explode
                Explode();
            }
            else if (other.tag == "Shield")
            {
                Debug.Log("Hit shield");
                Destroy(gameObject);
                shield_Script.Reflect_Projectile();
            }
        }

        
    }
    
    void Explode()
    {
        print("exploded");
        //creates a sphere at the projectile's position with a radius of projectileImpactRadius
        Collider[] colliders = Physics.OverlapSphere(transform.position, projectileImpactRadius);
        //checks if the sphere collides with the player object
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.tag == "Player")
            {
                //if the sphere collides with the player, the player will take damage
                //nearbyObject.GetComponent<PlayerHealth>().TakeDamage(10); //this requires a PlayerHealth script on the player
                Debug.Log("Player Hit!");
            }
        }

        if (explosionVisuals!=null)
        {
            Instantiate(explosionVisuals, transform.position, transform.rotation); //if there is an explosionVisuals object, it will be instantiated
        }
        
        
        //destroys the projectile
        Destroy(gameObject);
    }
}
