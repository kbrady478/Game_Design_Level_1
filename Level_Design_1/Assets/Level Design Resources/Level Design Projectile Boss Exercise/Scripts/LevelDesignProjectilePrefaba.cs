using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelDesignProjectilePrefab : MonoBehaviour
{
    private Player_Shield shield_Script;
    private Player_Stats stats_Script;
    private Bastard_Hit stun_Script;
    public GameObject player_Projectile;
    
    public float projectileSpeed;
    public float projectileImpactRadius;
    public float projectileLifetime;
    
    public GameObject explosionVisuals;
    
    public AudioSource audio_Component;
    public AudioClip audio_Clip;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shield_Script = FindObjectOfType<Player_Shield>();
        stats_Script = FindObjectOfType<Player_Stats>();
        stun_Script = FindObjectOfType<Bastard_Hit>();
        
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
        if (player_Projectile && player_Projectile.tag == "Player_Projectile")
        {
            if (other.tag == "Bastard")
            {
                Debug.Log("bastard hit");
                stun_Script.Bastard_Stun();
                Explode();
            }
        }
        else
        {
            
            if (other.tag == "Shield")
            {
                Debug.Log("Hit shield");
                Destroy(gameObject);
                shield_Script.Reflect_Projectile();
                //reflect_Script.Reflected_Spawn();

            }
            else if (other.tag != "Bastard")
            {
                print(gameObject.tag);
                print(other.tag);
                //if the projectile collides with an object, it will explode
                Explode();
            }
        }
    }
    
    void Explode()
    {
        audio_Component.PlayOneShot(audio_Clip);
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
                stats_Script.dealt_Damage();
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
